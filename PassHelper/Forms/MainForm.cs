using System;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

using PassHelper.UI;

namespace PassHelper.Forms {

    public partial class MainForm : Form {

        private readonly NameValueCollection Args = ParseArgs();

        public MainForm() {

            InitializeComponent();

            ttCert.SetToolTip(cbCerts, "Certificate to use for cryptographic operations");
            ttSrc.SetToolTip(txtSrc, "String to sign which used for ganarating password");
            ttFormat.SetToolTip(cbFormat, "Format of the password");
            ttEncryptedData.SetToolTip(txtEncryptedData, "Encrypted data in Base64 encoding");
            ttSecret.SetToolTip(txtSecret, "Generated password or string to encrypt");
        }

        private static NameValueCollection ParseArgs() {

            var result = new NameValueCollection();

            foreach (var arg in Environment.GetCommandLineArgs()) {

                var kvp = arg.Split('=');

                string key = kvp.Length >= 1 ? kvp[0] : "";
                string value = kvp.Length >= 2 ? kvp[1] : "";

                result[key] = value;
            }

            return result;
        }

        private void MakePassword() {

            var dataBytes = Encoding.UTF8.GetBytes(txtSrc.Text.Trim());

            var sign = GetPrivateKey().SignData(dataBytes, "sha512");

            try {

                var pass = PasswordConverter.Convert(new MemoryStream(sign), cbFormat.Text);

                try {
                    txtSecret.Text = new string(pass);
                }
                finally {
                    Array.Clear(pass, 0, pass.Length);
                }
            }
            finally {
                Array.Clear(sign, 0, sign.Length);
            }
        }

        private void MakeKeyfile() {

            var dlg = new SaveFileDialog();

            if (dlg.ShowDialog() != DialogResult.OK) {
                return;
            }

            var dataBytes = Encoding.ASCII.GetBytes(txtSrc.Text.Trim());

            var sign = GetPrivateKey().SignData(dataBytes, "sha512");

            try {
                File.WriteAllBytes(dlg.FileName, sign);
            }
            finally {
                Array.Clear(sign, 0, sign.Length);
            }
        }

        private void Encrypt() {

            if (string.IsNullOrWhiteSpace(txtSecret.Text)) {
                MessageBox.Show(
                    "Secret is empty, nothing to encrypt!", 
                    "Warning", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            var dataBytes = Encoding.UTF8.GetBytes(txtSecret.Text.Trim());

            var cipherBytes = GetPublicKey().Encrypt(dataBytes, fOAEP: false);

            txtEncryptedData.Text = Convert.ToBase64String(cipherBytes, Base64FormattingOptions.InsertLineBreaks);
        }

        private void Decrypt() {

            var cipherBytes = Convert.FromBase64String(txtEncryptedData.Text.Trim());

            var plainBytes = GetPrivateKey().Decrypt(cipherBytes, false);

            try {
                txtSecret.Text = Encoding.UTF8.GetString(plainBytes);
            }
            finally {
                Array.Clear(plainBytes, 0, plainBytes.Length);
            }
        }


        private RSACryptoServiceProvider GetPrivateKey() {

            var store = new X509Store(StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            try {
                return (RSACryptoServiceProvider)store.Certificates
                  .OfType<X509Certificate2>()
                  .Single(c => GenerateName(c) == (string)cbCerts.SelectedItem)
                  .PrivateKey;
            }
            finally {
                store.Close();
            }
        }

        private RSACryptoServiceProvider GetPublicKey() {

            var store = new X509Store(StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            try {
                return (RSACryptoServiceProvider)store.Certificates
                  .OfType<X509Certificate2>()
                  .Single(c => GenerateName(c) == (string)cbCerts.SelectedItem)
                  .PublicKey
                  .Key;
            }
            finally {
                store.Close();
            }
        }


        private void btnShow_MouseDown(object sender, MouseEventArgs e) {
            txtSecret.UseSystemPasswordChar = false;
        }

        private void btnShow_MouseUp(object sender, MouseEventArgs e) {
            txtSecret.UseSystemPasswordChar = true;
        }

        private void btnClear_Click(object sender, EventArgs e) {
            txtSecret.Text = string.Empty;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Clipboard.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            cbFormat.SelectedIndex = 0;
            cbCommand.SelectedIndex = 0;
            AcceptButton = btnGo;

            var store = new X509Store(StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            try {
                var certStrings = store.Certificates
                  .OfType<X509Certificate2>()
                  .Select(GenerateName)
                  .Where(name => name != null);

                foreach (var certString in certStrings) {
                    cbCerts.Items.Add(certString);
                }
            }
            finally {
                store.Close();
            }

            var pubKeyArg = Args["--pubkey"];

            if (!string.IsNullOrWhiteSpace(pubKeyArg)) {
                foreach (var certString in cbCerts.Items.OfType<string>()) {
                    if (certString.StartsWith(pubKeyArg, StringComparison.OrdinalIgnoreCase)) {
                        cbCerts.SelectedItem = certString;
                        break;
                    }
                }
            }
        }

        private static string GenerateName(X509Certificate2 cert) {

            if (!cert.HasPrivateKey) {
                return null;
            }

            RSACryptoServiceProvider privateKey;

            try {
                privateKey = (RSACryptoServiceProvider)cert.PrivateKey;
            }
            catch (Exception) {
                return null;
            }

            var modulus = privateKey.ExportParameters(false).Modulus;

            var modulusHex = BitConverter.ToString(modulus)
                .Replace("-", "")
                .Substring(0, 8);

            return $"{modulusHex} | {cert.GetNameInfo(X509NameType.SimpleName, false)}";
        }

        private void btnPwd_Click(object sender, EventArgs e) {
            MakePassword();
        }

        private void btnSign_Click(object sender, EventArgs e) {
            MakeKeyfile();
        }

        private void btnDecrypt_Click(object sender, EventArgs e) {
            Decrypt();
        }

        private void btnEncrypt_Click(object sender, EventArgs e) {
            Encrypt();
        }

        private void btnType_MouseDown(object sender, MouseEventArgs e) {
            Cursor = Cursors.Cross;
        }

        private void btnType_MouseUp(object sender, MouseEventArgs e) {

            Cursor = Cursors.Default;

            var handle = UIHelper.GetPointedWindow(Cursor.Position);
            if (handle == Handle || handle == btnType.Handle) {
                return;
            }

            UIHelper.Click(Cursor.Position);

            UIHelper.TypeText(txtSecret.Text,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromMilliseconds(50));
        }

        private void btnGo_Click(object sender, EventArgs e) {
            switch (cbCommand.SelectedIndex) {

                case 0:
                    MakePassword();
                    break;

                case 1:
                    MakeKeyfile();
                    break;

                case 2:
                    Encrypt();
                    break;

                case 3:
                    Decrypt();
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e) {

            cbFormat.SelectedIndex = 0;
            cbCommand.SelectedIndex = 0;

            txtSrc.Text = string.Empty;
            txtSecret.Text = string.Empty;
            txtEncryptedData.Text = string.Empty;

            Clipboard.Clear();
        }
    }
}
