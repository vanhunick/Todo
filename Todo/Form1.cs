﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Todo.control;

namespace Todo {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void panel1_Click(object sender, EventArgs e) {
            SolidBrush solidbrush = new SolidBrush(Color.Red);
            Graphics g = panel1.CreateGraphics();
            g.FillRectangle(solidbrush, 50, 50, 100, 50);
            Point p = new Point();
            p.X = 200;
            p.Y = 200;

            control.CheckBox box = new control.CheckBox(p);
            box.draw(g);

        }
    }
}
