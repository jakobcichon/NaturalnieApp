using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using NaturalnieApp.Database;
using NaturalnieApp.Dymo_Printer;
using NaturalnieApp.Forms.Common;

namespace NaturalnieApp.Forms
{
    public partial class Playground : UserControl
    {
        //====================================================================================================
        //Class fields
        #region Class fields
        DatabaseCommands databaseCommands;
        #endregion
        //====================================================================================================
        //Class constructor
        #region Class consturctor
        public Playground()
        {
            InitializeComponent();

            //Set double buffering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);
            databaseCommands = new DatabaseCommands();
        }


        #endregion


        private void bSave_Click(object sender, EventArgs e)
        {

        }


        private void Playground_Load(object sender, EventArgs e)
        {
           
        }

        private void bTestButton_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Czy na pewno chcesz zmienić nazwy produktów w Elzab?", "Zmiana nazw", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!
                List<Product> products = databaseCommands.GetAllProductsEnts();
                List<Product> noPassValidationProducts = new List<Product>();
                string acceptedChars = @"a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ0-9%.,/\s";
                int fixedCounter = 0;
                int notFixedCounter = 0;


                foreach (Product product in products)
                {
                    if (!Validation.ElzabProductNameValidation(product.ElzabProductName, throwException: false))
                    {
                        noPassValidationProducts.Add(product);

                    }
                }

                foreach (Product product in noPassValidationProducts)
                {
                    List<string> charsToReplace = ElzabRelated.FindUnspecifiedCharacters(product.ElzabProductName, acceptedChars);
                    foreach (string charToRemove in charsToReplace)
                    {
                        product.ElzabProductName = product.ElzabProductName.Replace(charToRemove, ".");
                        fixedCounter++;
                    }


                    if (!Validation.ElzabProductNameValidation(product.ElzabProductName, throwException: false))
                    {
                        notFixedCounter++;
                    }

                }

                result = MessageBox.Show($"Udało się naprawić: {fixedCounter} nazw.\nNie udało się naprawić: {notFixedCounter} nazw.\n" +
                    $"Czy zapisać do bazy danych?", "Zapis do bazy danych", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    foreach (Product product in noPassValidationProducts)
                    {
                        databaseCommands.EditProduct(product);

                    }
                    MessageBox.Show("Udało się zapisać do bazy danych!");

                }

                MessageBox.Show("Anulowano!");

                MessageBox.Show("Rozpoczne wyszukiwanie podwójnych nazw!");

                // Check if no double names
                Dictionary<Product, Product> doubleElzabNames = new Dictionary<Product, Product>();

                foreach (Product product in products)
                {
                    bool resultDouble = databaseCommands.CheckIfElzabProductNameExist(product.ElzabProductName, product.Id);
                    if (resultDouble)
                    {
                        Product product2 = databaseCommands.GetProductEntityByElzabName(product.ElzabProductName, product.Id);

                        // Do not add, of already added
                        bool doNotAdd = false;
                        foreach (Product key in doubleElzabNames.Keys)
                        {
                            if (key.Id == product2.Id)
                            {
                                doNotAdd = true;
                                break;
                            }
                        }
                        if (!doNotAdd)
                        {
                            doubleElzabNames.Add(product, product2);
                        }

                    }
                }

                if(doubleElzabNames.Count > 0)
                {
                    string elementsString = "";
                    foreach(var element in doubleElzabNames)
                    {
                        elementsString += "Nazwa :" + element.Key.ElzabProductName + "; DB Id numer 1: " + element.Key.Id.ToString() +
                        "; DB Id numer 1: " + element.Value.Id.ToString() + "\n";
                    }

                    MessageBox.Show("Znaleziono podwojone nazwy !\n" + elementsString);
                }


                ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Product> badBarcodes = this.databaseCommands.GetProductsWithInternalBarcodeOutOfLimits();


            ;
        }
    }
}
