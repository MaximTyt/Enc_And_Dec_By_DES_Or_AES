using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Enc_And_Dec_By_DES_Or_AES
{
    public partial class FileEncAndDec : Form
    {        
        private string sourceFile;
        public FileEncAndDec()
        {
            InitializeComponent();            
        }
        
        

        private void fileDrop_DragDrop(object sender, DragEventArgs e)
        {   string[] obj = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (!Directory.Exists(obj[0]))
            {
                EncOrDec.Enabled = true;                
                label1.Text = obj[0].Split('\\').Last();
                sourceFile = obj[0];
                if (obj[0].ToString().EndsWith(".enc"))
                    EncOrDec.Text = "Расшифровать";
                else
                    EncOrDec.Text = "Зашифровать";
            }
        }

        private void fileDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                string[] obj = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (!Directory.Exists(obj[0]))
                {                    
                    label1.Text = obj[0].Split('\\').Last();                                        
                }
            }
        }

        private void fileDrop_DragLeave(object sender, EventArgs e)
        {
            label1.Text = "Перетащите сюда файл или нажмите на область, чтобы выбрать файл";
        }

        public bool DesEncryptData(string inputFile, string outputFile, string cryptoKey)
        {
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    // Set the key and initialization vector                    
                    des.Key = ASCIIEncoding.ASCII.GetBytes(cryptoKey);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(cryptoKey);

                    // Create the input and output file streams
                    using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    using (FileStream outputFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                    {
                        // Create a CryptoStream and encrypt the file
                        using (CryptoStream cryptoStream = new CryptoStream(outputFileStream, des.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            // Read the input file and write it to the CryptoStream
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                cryptoStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show(this, e.ToString(), "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                File.Delete(outputFile);
                return false;
            }
        }
                
        public bool DesDecryptData(string inputFile, string outputFile, string cryptoKey)
        {
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    // Set the key and initialization vector
                    des.Key = ASCIIEncoding.ASCII.GetBytes(cryptoKey);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(cryptoKey);

                    // Create the input and output file streams
                    using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    using (FileStream outputFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                    {
                        // Create a CryptoStream and decrypt the file
                        using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, des.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            // Read the decrypted data and write it to the output file
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                outputFileStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show(this, e.ToString(), "Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                File.Delete(outputFile);
                return false;
            }
        }

        public bool AesEncryptData(string inputFile, string outputFile, string cryptoKey)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    // Set the key and initialization vector
                    aes.Key = Encoding.UTF8.GetBytes(cryptoKey);
                    aes.IV = new byte[16];

                    // Create the input and output file streams
                    using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    using (FileStream encryptedFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                    {
                        // Create a CryptoStream and encrypt the file
                        using (CryptoStream cryptoStream = new CryptoStream(encryptedFileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            // Read the input file and write it to the CryptoStream
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                cryptoStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show(this, e.ToString(), "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                File.Delete(outputFile);
                return false;
            }
        }

        public bool AesDecryptData(string inputFile, string outputFile, string cryptoKey)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    // Set the key and initialization vector
                    aes.Key = Encoding.UTF8.GetBytes(cryptoKey);
                    aes.IV = new byte[16];

                    // Create the input and output file streams
                    using (FileStream encryptedFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    using (FileStream decryptedFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                    {
                        // Create a CryptoStream and decrypt the file
                        using (CryptoStream cryptoStream = new CryptoStream(encryptedFileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            // Read the decrypted data and write it to the output file
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                decryptedFileStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show(this, e.ToString(), "Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                File.Delete(outputFile);
                return false;
            }
        }

        

        private void fileDrop_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select the source file to encrypt";
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                EncOrDec.Enabled = true;
                sourceFile = openFileDialog.FileName;
                label1.Text = sourceFile.Split('\\').Last();
                if (sourceFile.EndsWith(".enc"))
                    EncOrDec.Text = "Расшифровать";
                else
                    EncOrDec.Text = "Зашифровать";
            }
        }

        private void fileDrop_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Green, 2);
            pen.DashPattern = new float[] {2, 2};
            e.Graphics.DrawRectangle(pen, 1, 1, fileDrop.Width - 2, fileDrop.Height - 2);
        }

        private void EncOrDec_Click(object sender, EventArgs e)
        {
            if (strKey.Text.Length != 8 && rbDES.Checked)
                MessageBox.Show(this, "Длина ключа должна быть равна 8", "DES_SecretKey", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (strKey.Text.Length != 32 && rbAES.Checked)
                MessageBox.Show(this, "Длина ключа должна быть равна 32", "AES_SecretKey", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (EncOrDec.Text == "Зашифровать")
                {
                    string outputExt = '.' + sourceFile.Split('.').Last() + ".enc";
                    saveFileDialog1.Filter = $"Encrypted Files (*{outputExt})|*{outputExt}|All Files (*.*)|*.*";
                    saveFileDialog1.DefaultExt = outputExt;
                    if (rbDES.Checked)
                    {                        
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string outputFile = saveFileDialog1.FileName;
                            if (DesEncryptData(sourceFile, outputFile, strKey.Text) == true)
                                MessageBox.Show(this, "File encrypted and saved successfully!", "Encryption Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show(this, "The encryption process failed!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {                        
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string outputFile = saveFileDialog1.FileName;
                            if (AesEncryptData(sourceFile, outputFile, strKey.Text) == true)
                                MessageBox.Show(this, "File encrypted and saved successfully!", "Encryption Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show(this, "The encryption process failed!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                else
                {
                    string sourceExt = '.' + sourceFile.Replace(".enc", "").Split('.').Last();
                    saveFileDialog1.Filter = $"Decrypted Files (*{sourceExt})|*{sourceExt}|All Files (*.*)|*.*";
                    saveFileDialog1.DefaultExt = sourceExt;
                    if (rbDES.Checked)
                    {                        
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string outputFile = saveFileDialog1.FileName;
                            if (DesDecryptData(sourceFile, outputFile, strKey.Text) == true)
                                MessageBox.Show(this, "File decrypted and saved successfully!", "Decryption Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show(this, "The decryption process failed!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {                        
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string outputFile = saveFileDialog1.FileName;
                            if (AesDecryptData(sourceFile, outputFile, strKey.Text) == true)
                                MessageBox.Show(this, "File decrypted and saved successfully!", "Decryption Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show(this, "The decryption process failed!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }

        private void rbDES_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDES.Checked)
            {
                strKey.MaxLength = 8;
                strKey.Text = "MySecret";
            }
        }

        private void rbAES_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAES.Checked)
            {
                strKey.MaxLength = 32;
                strKey.Text = "ItIsVerySecretKeyTrustMePlease))";
            }
        }

        private void genKey_Click(object sender, EventArgs e)
        {
            if (rbDES.Checked)
            {
                strKey.Text = "";
                while (strKey.TextLength != 8)
                {
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    byte[] key = des.Key;
                    strKey.Text = Encoding.ASCII.GetString(des.Key);
                }
            }
            else
            {
                strKey.Text = "";
                while (strKey.TextLength != 32)
                {
                    Aes aes = Aes.Create();
                    aes.KeySize = 256;
                    byte[] key = aes.Key;
                    strKey.Text = Encoding.ASCII.GetString(aes.Key);
                }
            }
        }
    }
}
