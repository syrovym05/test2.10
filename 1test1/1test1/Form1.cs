namespace _1test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.ShowIcon = false;
            this.Text = "Test";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                StreamReader streamReader = new StreamReader("matematika.txt");
                List<string> list = new List<string>();
                while (!streamReader.EndOfStream)
                {
                    string s = streamReader.ReadLine();
                    listBox1.Items.Add(s);
                    list.Add(s);                    
                }

                streamReader.Close();

                StreamWriter streamWriter = new StreamWriter("matematika.txt", false);
                double soucet = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    string[] s = list[i].Split(' ');
                    char znamenko = char.Parse(s[1]);
                    int a = int.Parse(s[0]);
                    int b = int.Parse(s[2]);

                    double vys = 0;
                    switch (znamenko)
                    {
                        case '+':
                            {
                                vys = a + b;
                                break;
                            }
                        case '-':
                            {
                                vys = a - b;
                                break;
                            }
                        case '*':
                            {
                                vys = a * b;
                                break;
                            }
                        case '/':
                            {
                                if (b == 0) throw new DivideByZeroException("Došlo k pokusu dìlení nulou!");
                                checked { vys = Math.Round((double)a / (double)b, 3); }                                    
                                break;
                            }
                    }
                    
                    soucet += vys;
                    string zapis = String.Format("{0} {1} {2} = {3}", a, znamenko, b, vys);
                    streamWriter.WriteLine(zapis);
                    listBox2.Items.Add(zapis);


                }

                streamWriter.Close();

                double prumer = Math.Round(soucet / list.Count, 2);

                FileStream fileStream = new FileStream("prumer.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter(fileStream);
                MessageBox.Show("Prumer: " + prumer);

                binaryWriter.Write(prumer);
                binaryWriter.Close();
            }
            catch(DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArithmeticException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        


        
    }
}