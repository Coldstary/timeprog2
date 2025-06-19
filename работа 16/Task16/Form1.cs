using System;
using System.Windows.Forms;

namespace Task16
{
    public partial class FrmTask16 : Form
    {
        public FrmTask16()
        {
          
                InitializeComponent();
            }

            private void buttonInput_Click(object sender, EventArgs e)
            {
                // Проверка видимости поля ввода
                if (txtInput.Visible == false)
                {
                    // Показываем поле ввода при первом нажатии
                    txtInput.Visible = true;
                    txtInput.Text = "";
                    txtInput.Focus();  // Устанавливаем фокус ввода
                }
                else
                {
                    // Обработка введенного текста
                    string inputText = txtInput.Text.Trim();

                    if (string.IsNullOrEmpty(inputText))
                    {
                        // Показ предупреждения при пустом вводе
                        MessageBox.Show("Поле ввода не может быть пустым.",
                                       "Ошибка ввода",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Установка введенного текста в textBox2
                        lbl.Text = inputText;
                    }
                }
            }

            private void buttonClear_Click(object sender, EventArgs e)
            {
                // Проверка содержимого textBox2
                if (string.IsNullOrEmpty(lbl.Text))
                {
                    // Сообщение, если поле уже пустое
                    MessageBox.Show("Ярлык уже пуст.",
                                   "Очистка",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                }
                else
                {
                    // Очистка textBox2
                   lbl.Text = "";
                }
            }

            // Остальные методы остаются без изменений
            private void label1_Click(object sender, EventArgs e) { }
            private void textBox1_TextChanged(object sender, EventArgs e) { }
            private void TextBox1_Load(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
    }