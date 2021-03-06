﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DroneCodeGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var lines = txt.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).Where(line => !String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line)).ToList();

            var ln1 = lines.Select(line => line.Split(' ')[0]).ToList();
            var ln2 = lines.Select(line => line.Split(' ')[1]).ToList();

            var execTimes = new List<int>();

            var commands = new List<int>();

            for (var index1 = 0; index1 < ln1.Count; index1++)
            {
                if (index1 == 0)
                {
                    execTimes.Add(Convert.ToInt32(ln1[index1]) + 1);
                }
                else
                {
                    execTimes.Add(Convert.ToInt32(ln1[index1]));
                }
                commands.Add(Convert.ToInt32(ln2[index1]));
            }


            StringBuilder builder = new StringBuilder();

            builder.AppendLine("LDA [1000]");
            builder.AppendLine("ADDA 1");
            builder.AppendLine("STA [1000]");
            int nextInstr = 8;
            for (int index = 0; index < execTimes.Count - 1; index++)
            {
                builder.AppendLine("SUBA " + (execTimes[index]));
                builder.AppendLine("JGE " + nextInstr);
                builder.AppendLine("LDA " + commands[index]);
                builder.AppendLine("STA [0]");
                builder.AppendLine("HLT");
                nextInstr += 5;
            }
            var indexLast = execTimes.Count - 1;
            builder.AppendLine("LDA " + commands[indexLast]);
            builder.AppendLine("STA [0]");
            builder.AppendLine("HLT");



            code.Text = builder.ToString();
        }
    }
}
//STA[0]
//LDA[1000]
//SUBA 1
//STA[1000]
//HLT



//builder.AppendLine("LDA [1000]");

//            var jgeIndex = execTimes.Count() * 2 + 1;
//execTimes[0] = (Convert.ToInt32(execTimes[0]) - 1).ToString();
//            foreach (var exec in execTimes)
//            {
//                builder.AppendLine("ADDA " + exec)

//                    .AppendLine("JGE " + jgeIndex);
//jgeIndex += 2;
//            }
//            jgeIndex -= 1;
//            int count = 0;
//            foreach (var cmd in commands)
//            {
//                count++;
//                builder.AppendLine("LDA " + cmd);
//                if(count != commands.Count())
//                {
//                    builder.AppendLine("JGE " + jgeIndex);
//                }
//            }

//            builder.AppendLine("STA [0]");
//            builder.AppendLine("LDA [1000]");
//            builder.AppendLine("SUBA 1");
//            builder.AppendLine("STA [1000]");
//            builder.AppendLine("HLT");