using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba3
{
    public partial class Form1 : Form
    {
        string[] hillers;
        string[] tanks;
        string[] high_damage;
        string[] powerUpGroup;
        string[] powerfulArmor;
        string[] longRange;
        string[] closeRange;
        string[] spellSlots;

        string[] tiit;

        List<string> ANS;

        CheckBox[] answerYes;
        CheckBox[] answerNo;

        List<string[]> classes;

        public Form1()
        {
            InitializeComponent();

            answerYes = new CheckBox[8] { checkBox1, checkBox3, checkBox5, checkBox7, checkBox9, checkBox11, checkBox13, checkBox15 };
            answerNo = new CheckBox[8] { checkBox2, checkBox4, checkBox6, checkBox8, checkBox10, checkBox12, checkBox14, checkBox16 };

            hillers = new string[2] { "Паладин", "Жрец" };
            tanks = new string[3] { "Воин", "Варвар", "Паладин" };
            high_damage = new string[2] { "Воин", "Варвар" };
            powerUpGroup = new string[3] { "Воин", "Жрец", "Волшебник" };
            powerfulArmor = new string[2] { "Воин", "Паладин" };
            longRange = new string[3] { "Следопыт", "Волшебник", "Жрец" };
            closeRange = new string[4] { "Плут", "Воин", "Варвар", "Паладин" };
            spellSlots = new string[3] { "Паладин", "Жрец", "Волшебник" };

            classes = new List<string[]>() { hillers, tanks, high_damage, powerUpGroup, powerfulArmor, longRange, closeRange, spellSlots };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ANS = new List<string>();

            for (int i = 0; i < answerYes.Length; i++)
            {
                if (answerYes[i].Checked)
                {
                    if (ANS.Count == 0)
                    {
                        tiit = classes[i];
                        for (int j = 0; j < tiit.Length; j++)
                        {
                            ANS.Add(tiit[j]);
                        }
                    }
                    else
                    {
                        tiit = classes[i];
                        for (int j = 0; j < ANS.Count; j++)
                        {
                            if (!tiit.Contains(ANS[j]))
                            {
                                ANS.Remove(ANS[j]);
                            }
                        }
                    }
                }

                if (answerNo[i].Checked)
                {
                    tiit = classes[i];
                    for (int j = 0; j < ANS.Count; j++)
                    {
                        if (tiit.Contains(ANS[j]))
                        {
                            ANS.Remove(ANS[j]);
                        }
                    }
                }
            }

            string text = "";

            for(int i = 0; i < ANS.Count; i++)
            {
                text += ANS[i] + " ";
            }

            if(ANS.Count == 0)
            {
                MessageBox.Show("Мы не подобрали вам класс :(");
            }
            else
            {
                MessageBox.Show("Рекомендуемый класс: \n" + text + "\n");
            }
        }
    }
}
