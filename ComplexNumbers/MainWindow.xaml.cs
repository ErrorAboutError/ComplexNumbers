using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComplexNumbers
{
    
    public partial class MainWindow : Window
    {
        double realPartFirst; // Действительная часть первого числа
        double imaginaryPartFirst; // Мнимая часть первого числа
        int rootDegree;  // Степень корня первого комплексного числа

        double realPartSecond; // Действительная часть первого числа
        double imaginaryPartSecond; // Мнимая часть первого числа
        int rootDegreeSecond;  // Степень корня первого комплексного числа

        double coefM; // Коэффициент M
        double coefN; // Коэффициент N


        public MainWindow()
        {
            InitializeComponent();
        }
        // Метод для подсчёта корней комплексных чисел
        private void Roots_Click(object sender, RoutedEventArgs e)
        {
            ComplexNumber complexFirst = new ComplexNumber();
            ComplexNumber complexSecond = new ComplexNumber();
            bool tmp = false;
            bool tmpTwo = false;
            try
            {
                if (CofReal.Text !="" || CofImaginary.Text != "")
                {
                    realPartFirst = Convert.ToDouble(CofReal.Text);
                    imaginaryPartFirst = Convert.ToDouble(CofImaginary.Text);
                    rootDegree = Convert.ToInt32(CofRootDegree.Text);
                    
                    if (CofRootM.Text=="")
                    {
                        coefM = 1;
                    }
                    else
                    {
                        try
                        {
                            coefM = Convert.ToDouble(CofRootM.Text);
                            realPartFirst = coefM * realPartFirst;
                            imaginaryPartFirst = coefM * imaginaryPartFirst;
                        } catch (Exception ex)
                        {
                            MessageBox.Show("Неверный ввод данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                       
                    }
                    complexFirst = new ComplexNumber(realPartFirst, imaginaryPartFirst);
                    tmp = true;
                }
                
                if (CofRealSecond.Text != "" || CofImaginarySecond.Text != ""){
                    realPartSecond = Convert.ToDouble(CofRealSecond.Text);
                    imaginaryPartSecond = Convert.ToDouble(CofImaginarySecond.Text);
                    rootDegreeSecond = Convert.ToInt32(CofRootDegreeSecond.Text);
                    
                    if (CofRootN.Text == "")
                    {
                       
                        coefN = 1;
                    }
                    else
                    {
                        try
                        {
                            coefN = Convert.ToDouble(CofRootM.Text);

                            realPartSecond = coefN * realPartSecond;
                            imaginaryPartSecond = coefN * imaginaryPartSecond;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Неверный ввод данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                    complexSecond = new ComplexNumber(realPartSecond, imaginaryPartSecond);
                    tmpTwo = true;

                }               
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (tmp)
            {
                // Подсчёт корней первого числа
                ComplexNumber[] massiveRoots = ComplexNumber.ActionsWithComplexMD(complexFirst, rootDegree);
                string resultReceiver = ComplexNumber.DerivationRoots(massiveRoots, rootDegree);
                AnswerBlock.Text += "\nКорни первого комплексного числа:" + resultReceiver + "\n";
                if (tmpTwo == false) { AnswerBlock.Text += "Второе комплексное число введено не было!\n"; }
            }
            if (tmpTwo)
            {
                // Подчсчёт корней второго числа
                ComplexNumber[] massiveRootsSecond = ComplexNumber.ActionsWithComplexMD(complexSecond, rootDegree);
                string resultReceiverSecond = ComplexNumber.DerivationRoots(massiveRootsSecond, rootDegreeSecond);

                AnswerBlock.Text += "\nКорни второго комплексного числа:" + resultReceiverSecond + "\n";
                if (tmp == false) { AnswerBlock.Text += "Первое комплексное число введено не было!\n"; }
            }
            if (tmp == false && tmpTwo == false) { MessageBox.Show("Операция невозможна так как вы не ввели все комплексные числа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); }
           

        }
        // Метод для работы со сложением двух компелксных чисел
        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            ComplexNumber complexFirst = new ComplexNumber();
            ComplexNumber complexSecond = new ComplexNumber();
            bool tmp = false;
            bool tmpTwo = false;
            try
            {
                if (CofReal.Text != "" || CofImaginary.Text != "")
                {
                    realPartFirst = Convert.ToDouble(CofReal.Text);
                    imaginaryPartFirst = Convert.ToDouble(CofImaginary.Text);
                    complexFirst = new ComplexNumber(realPartFirst, imaginaryPartFirst);
                    tmp = true;
                }

                if (CofRealSecond.Text != "" || CofImaginarySecond.Text != "")
                {
                    realPartSecond = Convert.ToDouble(CofRealSecond.Text);
                    imaginaryPartSecond = Convert.ToDouble(CofImaginarySecond.Text);
                    complexSecond = new ComplexNumber(realPartSecond, imaginaryPartSecond);
                    tmpTwo = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (tmp && tmpTwo)
            {
                var complexResult = ComplexNumber.ActionsWithComplex(complexFirst, complexSecond);
                AnswerBlock.Text += "\n\nРезультат сложения комплексных чисел:\n" + ComplexNumber.ComplexNumberOutput(complexResult);
            }
            else
            {
                MessageBox.Show("Операция невозможна так как вы не ввели все комплексные числа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        // Метод для работы с вычитанием компелксных чисел
        private void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            ComplexNumber complexFirst = new ComplexNumber();
            ComplexNumber complexSecond = new ComplexNumber();
            bool tmp = false;
            bool tmpTwo = false;
            try
            {
                if (CofReal.Text != "" || CofImaginary.Text != "")
                {
                    realPartFirst = Convert.ToDouble(CofReal.Text);
                    imaginaryPartFirst = Convert.ToDouble(CofImaginary.Text);
                    complexFirst = new ComplexNumber(realPartFirst, imaginaryPartFirst);
                    tmp = true;
                }

                if (CofRealSecond.Text != "" || CofImaginarySecond.Text != "")
                {
                    realPartSecond = Convert.ToDouble(CofRealSecond.Text);
                    imaginaryPartSecond = Convert.ToDouble(CofImaginarySecond.Text);
                    complexSecond = new ComplexNumber(realPartSecond, imaginaryPartSecond);
                    tmpTwo = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (tmp && tmpTwo)
            {
                var complexResult = ComplexNumber.ActionsWithComplexSub(complexFirst, complexSecond);
                AnswerBlock.Text += "\n\nРезультат вычитания комплексных чисел:\n" + ComplexNumber.ComplexNumberOutput(complexResult);
            }
            else
            {
                MessageBox.Show("Операция невозможна так как вы не ввели все комплексные числа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        // Метод для работы с умножением двух комплексных чисел
        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            ComplexNumber complexFirst = new ComplexNumber();
            ComplexNumber complexSecond = new ComplexNumber();
            bool tmp = false;
            bool tmpTwo = false;
            try
            {
                if (CofReal.Text != "" || CofImaginary.Text != "")
                {
                    realPartFirst = Convert.ToDouble(CofReal.Text);
                    imaginaryPartFirst = Convert.ToDouble(CofImaginary.Text);
                    complexFirst = new ComplexNumber(realPartFirst, imaginaryPartFirst);
                    tmp = true;
                }

                if (CofRealSecond.Text != "" || CofImaginarySecond.Text != "")
                {
                    realPartSecond = Convert.ToDouble(CofRealSecond.Text);
                    imaginaryPartSecond = Convert.ToDouble(CofImaginarySecond.Text);
                    complexSecond = new ComplexNumber(realPartSecond, imaginaryPartSecond);
                    tmpTwo = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (tmp && tmpTwo)
            {
                var complexResult = ComplexNumber.ActionsWithComplexMD(complexFirst, complexSecond);
                AnswerBlock.Text += "\n\nРезультат умножения комплексных чисел:\n" + ComplexNumber.ComplexNumberOutput(complexResult);
            }
            else
            {
                MessageBox.Show("Операция невозможна так как вы не ввели все комплексные числа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Метод для работы с делением двух комплексных чисел
        private void Division_Click(object sender, RoutedEventArgs e)
        {
            ComplexNumber complexFirst = new ComplexNumber();
            ComplexNumber complexSecond = new ComplexNumber();
            bool tmp = false;
            bool tmpTwo = false;
            try
            {
                if (CofReal.Text != "" || CofImaginary.Text != "")
                {
                    realPartFirst = Convert.ToDouble(CofReal.Text);
                    imaginaryPartFirst = Convert.ToDouble(CofImaginary.Text);
                    complexFirst = new ComplexNumber(realPartFirst, imaginaryPartFirst);
                    tmp = true;
                }

                if (CofRealSecond.Text != "" || CofImaginarySecond.Text != "")
                {
                    realPartSecond = Convert.ToDouble(CofRealSecond.Text);
                    imaginaryPartSecond = Convert.ToDouble(CofImaginarySecond.Text);
                    complexSecond = new ComplexNumber(realPartSecond, imaginaryPartSecond);
                    tmpTwo = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (tmp && tmpTwo)
            {
                var complexResult = ComplexNumber.ActionsWithComplexMDDiv(complexFirst, complexSecond);
                AnswerBlock.Text += "\n\nРезультат деления комплексных чисел:\n" + ComplexNumber.ComplexNumberOutput(complexResult);
            }
            else
            {
                MessageBox.Show("Операция невозможна так как вы не ввели все комплексные числа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Метод для отчищения (души) TextBox, в котором содержится ответ
        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            CofReal.Clear();
            CofImaginary.Clear();
            CofRealSecond.Clear();
            CofImaginarySecond.Clear();
            CofRootDegree.Clear();
            CofRootDegreeSecond.Clear();
            AnswerBlock.Clear();
        }

        private void TrigonometricForm_Click(object sender, RoutedEventArgs e)
        {
            ComplexNumber complexFirst = new ComplexNumber();
            ComplexNumber complexSecond = new ComplexNumber();
            bool tmp = false;
            bool tmpTwo = false;
            try
            {
                if (CofReal.Text != "" || CofImaginary.Text != "")
                {
                    realPartFirst = Convert.ToDouble(CofReal.Text);
                    imaginaryPartFirst = Convert.ToDouble(CofImaginary.Text);
                    complexFirst = new ComplexNumber(realPartFirst, imaginaryPartFirst);
                    tmp = true;
                }

                if (CofRealSecond.Text != "" || CofImaginarySecond.Text != "")
                {
                    realPartSecond = Convert.ToDouble(CofRealSecond.Text);
                    imaginaryPartSecond = Convert.ToDouble(CofImaginarySecond.Text);
                    complexSecond = new ComplexNumber(realPartSecond, imaginaryPartSecond);
                    tmpTwo = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (tmp)
            {
                AnswerBlock.Text += "\nТригонометрическая форма первого комплексного числа:\n " + ComplexNumber.TrigonometricView(complexFirst);
                if (!tmpTwo) { AnswerBlock.Text += "\nВторое комплексное число не указано!"; }
            }
            if (tmpTwo)
            {
                AnswerBlock.Text += "\nТригонометрическая форма второго комплексного числа:\n " + ComplexNumber.TrigonometricView(complexSecond);
                if (!tmp) { AnswerBlock.Text += "\nПервое комплексное число не указано!"; }
            }
                

            
            
        }
    }
}
