﻿using PrototipoSeguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PrototipoSeguridad
{
    public partial class Clientess : Form
    {
        public Clientess()
        {
           InitializeComponent();
        }
        
        int caseSwitch = 0;

        private void navegador1_NavInsertar(object sender, EventArgs e)
        {
            caseSwitch = 1;
        }

        private void navegador1_NavActualizar(object sender, EventArgs e)
        {
            caseSwitch = 2;
        }

        private void navegador1_NavGuardar(object sender, EventArgs e)
        {
            switch (caseSwitch)
            {
                case 1:
                    Navegador.INSERCION obj = new Navegador.INSERCION();
                    foreach (Control _textbox in this.Controls)
                    {
                        if (_textbox is TextBox && _textbox.Text != string.Empty)
                        {
                            obj.CREANDOSQL(_textbox.Tag.ToString());
                        }

                        if (_textbox is ComboBox && _textbox.Text != string.Empty)
                        {
                            obj.CREANDOSQL(_textbox.Tag.ToString());
                        }
                    }
                    obj.value();
                    foreach (Control _textbox in this.Controls)
                    {
                        if (_textbox is TextBox && _textbox.Text != string.Empty)
                        {
                            obj.CREANDOSQL2(_textbox.Text);
                        }
                        if (_textbox is ComboBox && _textbox.Text != string.Empty)
                        {
                            obj.CREANDOSQL2(_textbox.Text);
                        }
                    }
                    obj.coma();
                    break;

                case 2:
                    Navegador.ACTUALIZAR obj2 = new Navegador.ACTUALIZAR();
                    foreach (Control _textbox in this.Controls)
                    {
                        if (_textbox is TextBox && _textbox.Name == "primarykey")
                        {
                            obj2.COMPARACION(_textbox.Text, _textbox.Tag.ToString());
                        }
                        else if (_textbox is TextBox && _textbox.Name != string.Empty)
                        { obj2.CREANDOSQL(_textbox.Text, _textbox.Tag.ToString()); }

                        if (_textbox is ComboBox && _textbox.Name == "primarykey")
                        {
                            obj2.COMPARACION(_textbox.Text, _textbox.Tag.ToString());
                        }
                        else if (_textbox is ComboBox && _textbox.Name != string.Empty)
                        { obj2.CREANDOSQL(_textbox.Text, _textbox.Tag.ToString()); }
                    }
                    obj2.coma();
                    obj2.finalizarsql();
                    break;
                    
                case 3:
                    Navegador.ELIMINAR obj3 = new Navegador.ELIMINAR();
                    foreach (Control _textbox in this.Controls)
                    {
                        if (_textbox is TextBox && _textbox.Name == "primarykey")
                        {
                            obj3.finalizarsql(_textbox.Text, _textbox.Tag.ToString());
                        }
                        
                        if (_textbox is ComboBox && _textbox.Name == "primarykey")
                        {
                            obj3.finalizarsql(_textbox.Text, _textbox.Tag.ToString());
                        }
                    }
                    break;
            }
        }

        private void navegador1_NavEliminar(object sender, EventArgs e)
        {
            caseSwitch = 3;
        }

        private void Clientess_Load(object sender, EventArgs e)
        {
        }

        private void navegador1_NavSalir(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
        }
    }
}