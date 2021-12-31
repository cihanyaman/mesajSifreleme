using System;
using System.Windows.Forms;


namespace Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Form_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip explanation = new ToolTip();
            explanation.ToolTipTitle = "Instruction!";
            explanation.ToolTipIcon = ToolTipIcon.Warning;
            explanation.IsBalloon = true;

            explanation.SetToolTip(btn_Decrypt, "Düğmeye tıklamadan önce şifresi çözülen metni üstteki metin kutusuna yapıştırın");
        }
        #endregion


        #region ChecBoxes
        private void checkBoxSPN_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSPN.Checked == true)
            {
                checkBoxSHA.Checked = false;
            }
            
        }

        private void checkBoxSHA_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA.Checked == true)
            {
                checkBoxSPN.Checked = false;
            }
        }
        #endregion


        #region Encrytption Buttons
        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            txtPlain.Text = non_T_Chars(txtPlain.Text);
            if (txtPlain.Text == "") { MessageBox.Show("metin boş olamaz.", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }   // boş olamaz
            else if(txtKey.Text == "") { MessageBox.Show("anahtar boş olamaz", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else if (txtKey.Text.Length != 8) { MessageBox.Show("Anahtar 8 karakter uzunluğunda olmalıdır.", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {
                labelPText.Text = "Plain Text";
                labelCipher.Text = "Encrypted Text";
                if (checkBoxSPN.Checked == true )
                {
                    if (txtPlain.Text.Length % 2 == 1) { txtPlain.Text += " "; } // Spn her adımda 2 karakterle çalışır, bu nedenle Metin çift karakter uzunluğunda olmalıdır.
                    else
                    {
                        SPN_encryption spn = new SPN_encryption(txtPlain.Text, txtKey.Text);
                        txtCipher.Text = spn.encrypt();
                    }
                }
                else if (checkBoxSHA.Checked == true )
                {
                    SHA_encryption sha = new SHA_encryption(txtPlain.Text);
                    txtCipher.Text = sha.encrypt();
                }
                else if (checkBoxSPN.Checked == false && checkBoxSHA.Checked == false) { MessageBox.Show("İstediğiniz şifreleme yöntemini seçin ", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            }
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            if (txtPlain.Text == "") { MessageBox.Show("boş olamaz", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else if (txtKey.Text == "") { MessageBox.Show("anahtar boş olamaz.", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else if (txtKey.Text.Length != 8) { MessageBox.Show("anahtar 8 karekterli olmalı.", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {
                labelPText.Text = "Encrypted Text";
                labelCipher.Text = "Decrypted Text";

                if (checkBoxSPN.Checked == true)
                {
                    SPN_encryption spn = new SPN_encryption(txtKey.Text);
                    txtCipher.Text = spn.decrypt(txtPlain.Text);
                }
                else if (checkBoxSHA.Checked == true) { MessageBox.Show("SHA ya bağlanılamadı "); }
                else if (checkBoxSPN.Checked == false && checkBoxSHA.Checked == false) { MessageBox.Show("İstediğiniz şifre çözme yöntemini seçin ", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }
        #endregion


        #region Turkish characters Replace
        private string non_T_Chars(string text)
        {
            text = text.Replace("İ", "I");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "G");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "O");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "U");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "S");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "C");
            text = text.Replace("ç", "c");
            return text;
        }
        #endregion

    }
}
