using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HangmanDemo
{
    public partial class Form1 : Form
    {
        static string tempshow;
        static string strlives;

        //

        static string tempWord;
        static string word;
        static char[] show;

        static char input;
        const int livesMax = 5;
        static int lives = livesMax;
        static int left;

        static char[] entered;
        //static bool running;

        public Form1()
        {
            InitializeComponent();
        }


        public void enablebuttons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
            button25.Enabled = true;
            button26.Enabled = true;
        }

        public void disablebuttons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;
            button20.Enabled = false;
            button21.Enabled = false;
            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button25.Enabled = false;
            button26.Enabled = false;
        }


        private void txtstart_TextChanged(object sender, EventArgs e)
        {
            tempWord = txtstart.Text;

        }

        private void cbtstart_Click(object sender, EventArgs e)
        {
            if (txtstart.Text != "")
            {
                initialize(tempWord);
                enablebuttons();
                lblans.Text = show2();
                pnlstart.Visible = false;
            }

        }


        private void button_Click(object sender, EventArgs e)
        {
       
            var koumpi = (Button)sender;
            input = koumpi.Text.ToLower()[0];
            koumpi.Enabled = false;
            koumpi.BackColor = Color.Pink;
            
            processInput();
            lblans.Text = show2();

        }

        void processInput()
        {

            int i = 0;
            while (entered[i] != ' ')
            {
                i++;
            }

            entered[i] = input;

            if (substituteLetter(input))
            {
                if (left == 0)
                {
                    win();
                }
            }
            else
            {
                lives--;
                strlives = (lives).ToString();
                lbllives.Text = strlives;
                if (lives == 0)
                {
                    loose();
                }
            }
        }

        static bool substituteLetter(char l)
        {
            bool found = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == l)
                {
                    show[i] = l;
                    left--;
                    found = true;
                }
            }
            return found;
        }

        static void initialize(string newWord)
        {
            entered = new char[26];
            lives = livesMax;
            word = newWord;
            show = new char[word.Length];
            for (int i = 0; i < show.Length; i++)
            {
                show[i] = '*';
            }
            for (int i = 0; i < 26; i++)
            {
                entered[i] = ' ';
            }
            left = word.Length;
        }

        void win()
        {
            //Console.Out.WriteLine("Congrats!!");
            //running = continueQuerry();
            lblresult.Text = "Congrats!!";
            pnlresult.Visible = true;
            disablebuttons();
        }

        void loose()
        {
            //Console.Out.WriteLine("You lost, play again?");
            //running = continueQuerry();
            lblresult.Text = "You Lost";
            pnlresult.Visible = true;
            disablebuttons();
        }

        static string show2()
        {
            tempshow=new string(show);
            return tempshow;
        }


    }
}
