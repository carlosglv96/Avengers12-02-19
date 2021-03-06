﻿using Avengers.Dominio;
using Avengers.Dominio.Gestores;
using Avengers.Presentacion.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avengers.Presentacion.Invoices
{
    public partial class NewInvoices : Form
    {
        private int tempIdLine = 0;
        private String idioma;
        private User u;
        private DtoCustomer dtoCustomer;
        private DtoProduct dtoProduct;
        private DtoLine dtoLine;
        private List<DtoProduct> listProduct;
        private List<DtoLine> listLine;
        private float netprice = 0;
        private float priceIva = 0;
        private float acumuladortotalNeto = 0;
        private float acumuladortotalIva = 0;
        private readonly float IVA = 10;


        public NewInvoices(String idioma, User u)
        {
            this.idioma = idioma;
            this.u = u;
            listProduct = new List<DtoProduct>();
            listLine = new List<DtoLine>();
          
            InitializeComponent();
            initTable();


        }

        //private void idioma_en()
        //{
        //    lblAddLineInvoice.Text = Recursos.Ingles.lblAddLine;
        //    lblAddProductInvoice.Text = Recursos.Ingles.lblAddProduct;
        //    lblAmountInvoice.Text = Recursos.Ingles.lblAmount;
        //    lblAmountLine.Text = Recursos.Ingles.lblAmount;
        //    lblCustomerNewInvoice.Text = Recursos.Ingles.lblCustomer;
        //    lblDescriptionInvoice.Text = Recursos.Ingles.lblDescrip;
        //    lblPriceInvoice.Text = Recursos.Ingles.lblPrice;
        //    lblPriceProduct.Text = Recursos.Ingles.lblPrice;
        //    lblProductInvoice.Text = Recursos.Ingles.lblProduct;
        //    lblNeto.Text = "Net Total";
        //    btnAdd.Text = Recursos.Ingles.btnAdd;
        //    btnAddLineInvoice.Text = Recursos.Ingles.btnAddLine;
        //    btnRemoveInvoice.Text = Recursos.Ingles.btnRemove;
        //    btnCancelInvoice.Text = Recursos.Ingles.btnCancel;
        //}

        //private void idioma_es()
        //{

        //    lblAddLineInvoice.Text = "Añadir Linea";
        //    //lblAddProductInvoice.Text = Recursos.Espanol.lblAddProduct;
        //    //lblAmountInvoice.Text = Recursos.Espanol.lblAmount;
        //    //lblAmountLine.Text = Recursos.Espanol.lblAmount;
        //    //lblCustomerNewInvoice.Text = Recursos.Espanol.lblCustomer;
        //    //lblDescriptionInvoice.Text = Recursos.Espanol.lblDescrip;
        //    //lblPriceInvoice.Text = Recursos.Espanol.lblPrice;
        //    //lblPriceProduct.Text = Recursos.Espanol.lblPrice;
        //    //lblProductInvoice.Text = Recursos.Espanol.lblProduct;
        //    //lblNeto.Text = "Total Neto";
        //    //btnAdd.Text = Recursos.Espanol.btnAdd;
        //    //btnAddLineInvoice.Text = Recursos.Espanol.btnAddLine;
        //    //btnRemoveInvoice.Text = Recursos.Espanol.btnRemove;
        //    //btnCancelInvoice.Text = Recursos.Espanol.btnCancel;
        //}

        public void initTable()
        {
            dgvInv.Columns.Clear();
            if (this.idioma == "ESPAÑOL")
            {
                dgvInv.Columns.Add("ID", "ID");
                dgvInv.Columns.Add("TYPE", "TIPO");
                dgvInv.Columns.Add("PRODUCT", "PRODUCTO");
                dgvInv.Columns.Add("AMOUNT", "CANTIDAD");
                dgvInv.Columns.Add("UNIPRICE", "PRECIO UNIDAD");
                dgvInv.Columns.Add("NET_AMOUNT", "PRECIO NETO");
                dgvInv.Columns.Add("PRICE", "PRECIO TOTAL");
            }
            else
            {
                dgvInv.Columns.Add("ID", "ID");
                dgvInv.Columns.Add("TYPE", "TIPO");
                dgvInv.Columns.Add("PRODUCT", "PRODUCT");
                dgvInv.Columns.Add("AMOUNT", "AMOUNT");
                dgvInv.Columns.Add("UNIPRICE", "UNIT PRICE");
                dgvInv.Columns.Add("NET_AMOUNT", "NET AMOUNT");
                dgvInv.Columns.Add("PRICE", "PRICE");


            }
            dgvInv.Columns["ID"].Visible = false;
            dgvInv.Columns["TYPE"].Visible = false;
            dgvInv.Columns["UNIPRICE"].Visible = false;
        }

        public void updateCustomer(DtoCustomer customer)
        {
            //Console.WriteLine(customer.Name+" "+ customer.Surname);
            this.dtoCustomer = customer;
            txtCustomer.Text = customer.Name + " " + customer.Surname;

        }
        public void updateProduct(DtoProduct product)
        {
            // Console.WriteLine(product.Name);
            this.dtoProduct = product;
            txtProduct.Text = product.Name;
            txtPriceProduct.Text = product.Price;

        }

        private void btnFindCust_Click_1(object sender, EventArgs e)
        {
            ViewCustomer vc = new ViewCustomer(this, this.idioma);

            vc.ShowDialog(this);
        }

        private void btnFindProd_Click(object sender, EventArgs e)
        {
            ViewProduct vp = new ViewProduct(this, this.idioma);
            vp.ShowDialog(this);
            this.nudAmount.Value = 1;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            if (checkProduct())
            {
                if (!searchProduct(dtoProduct))
                {
                    listProduct.Add(dtoProduct);
                    netprice = float.Parse(txtPriceProduct.Text.Replace(".", ",").Replace("'", "")) * float.Parse(nudAmount.Value.ToString());
                    netprice = (float)Math.Round(netprice, 2);
                    priceIva = netprice + (netprice * (IVA / 100));
                    priceIva = (float)Math.Round(priceIva, 2);

                    dgvInv.Rows.Add(dtoProduct.Idproduct, "P", dtoProduct.Name, nudAmount.Value, dtoProduct.Price, netprice, priceIva);

                    calcularTotales();

                    //insertamos en la tabla y borramos las casillas
                    clearproduct();
                }
                else
                {
                    for (int i = 0; i < dgvInv.RowCount; i++)
                    {
                        String id = dgvInv.Rows[i].Cells[0].Value.ToString();
                        String name = dgvInv.Rows[i].Cells[2].Value.ToString();
                        int amount = Int32.Parse(dgvInv.Rows[i].Cells[3].Value.ToString());
                        float price = float.Parse(dgvInv.Rows[i].Cells[4].Value.ToString());
                        float net_price = float.Parse(dgvInv.Rows[i].Cells[5].Value.ToString());
                        float preciomasiva = float.Parse(dgvInv.Rows[i].Cells[6].Value.ToString());

                        //si hay alguna coincidencia en la tabla de id y nombre sumamos cantidades y precios
                        
                        if (dtoProduct!=null && dtoProduct.Idproduct.Equals(id) && dtoProduct.Name.Equals(name))
                        {
                            int newamount = amount + Int32.Parse(nudAmount.Value.ToString());
                            dgvInv.Rows[i].Cells[3].Value = newamount;
                            net_price = net_price + (price * float.Parse(nudAmount.Value.ToString()));
                            net_price = (float)Math.Round(net_price, 2);
                            dgvInv.Rows[i].Cells[5].Value = net_price;

                            preciomasiva = net_price + (price *newamount* IVA / 100);
                            preciomasiva = (float)Math.Round(preciomasiva, 2);
                            dgvInv.Rows[i].Cells[6].Value = preciomasiva;

                            calcularTotales();
                            clearproduct();

                        }
                    }
                }
            }
        }
        private void calcularTotales()
        {
            float totalneto = 0;
            float total = 0;
            for (int i = 0; i < dgvInv.RowCount; i++)
            {
                float net_price = float.Parse(dgvInv.Rows[i].Cells[5].Value.ToString());
                float price_iva = float.Parse(dgvInv.Rows[i].Cells[6].Value.ToString());
                totalneto += net_price;
                totalneto = (float)Math.Round(totalneto, 2);
                
                total += price_iva;
                total = (float)Math.Round(total, 2);
            }
            txtTotal.Text = total.ToString();
            txtTotalNeto.Text = totalneto.ToString();
            acumuladortotalNeto = totalneto;
            acumuladortotalIva = total;

        }
        private void clearproduct()
        {
            dtoProduct = null;
            txtProduct.Text = null;
            nudAmount.Value = 1;
            txtPriceProduct.Text = null;
        }

        private bool checkProduct()
        {
            return (dtoProduct != null);
        }
        private bool checkLine()
        {
            return !String.IsNullOrEmpty(txtDesc.Text) && !String.IsNullOrEmpty(txtPriceLine.Text) && Utils.check.checkAmountPos(txtPriceLine.Text.Replace("'", ""));
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            if (checkLine())
            {
                this.tempIdLine++;
                netprice = float.Parse(txtPriceLine.Text.Replace(".", ",").Replace("'", "")) * float.Parse(nudAmountLine.Value.ToString());
                netprice = (float)Math.Round(netprice, 2);
                priceIva = netprice + (netprice * (IVA / 100));
                priceIva = (float)Math.Round(priceIva, 2);

                DtoLine dtoLine = new DtoLine(txtDesc.Text.Replace("'", ""), (nudAmountLine.Value).ToString(), netprice.ToString());
                //metemos un id temporar para luego distinguir al remover si es la linea q buscamos
                dtoLine.IdLine = tempIdLine.ToString();
                listLine.Add(dtoLine);
                dgvInv.Rows.Add(dtoLine.IdLine, "L", dtoLine.Description, dtoLine.Quantity, txtPriceLine.Text.Replace(".", ",").Replace("'", ""), netprice, priceIva);
                //acumuladortotalNeto += netprice;

                calcularTotales();
                //borramos las casillas
                txtDesc.Text = null;
                nudAmountLine.Value = 1;
                txtPriceLine.Text = null;

            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //sacamos todos los datos de la fila
                int id = Convert.ToInt16(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[0].Value.ToString());
                String tipo = dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[1].Value.ToString();
                String name = dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[2].Value.ToString();
                int amount = Convert.ToInt16(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[3].Value.ToString());
                float uniprice = float.Parse(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[4].Value.ToString());
                float net_amount = float.Parse(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[5].Value.ToString());
                float totalPrice = float.Parse(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[6].Value.ToString());

                //si la cantidad de elementos a quitar es mayor que la cantidad de elementos que hay
                if (nudRemove.Value >= amount)
                {

                    nudRemove.Value = 1;
                    dgvInv.Rows.RemoveAt(dgvInv.CurrentRow.Index);
                    calcularTotales();

                }
                else
                {
                    //cambiamos las cantidades
                    dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[3].Value = amount - nudRemove.Value;
                    //cambiamos el precio neto
                    net_amount -= uniprice * float.Parse(nudRemove.Value.ToString());
                    net_amount = (float)Math.Round(net_amount, 2);
                    dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[5].Value = net_amount;
                    //cambiamos el precio + iva
                    totalPrice -= uniprice * float.Parse(nudRemove.Value.ToString()) + (uniprice * IVA / 100);
                    totalPrice = (float)Math.Round(totalPrice, 2);
                    dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[6].Value = totalPrice;
                    //calculamos totales
                    calcularTotales();

                    //volvemos a poner nudRemove a 1
                    nudRemove.Value = 1;



                }

            }
            catch (Exception ex)
            {
                    MessageBox.Show((this.idioma == "ESPAÑOL")?"Debes seleccionar un Producto": "You must Select a Product");
            }


        }
        private bool searchProduct(DtoProduct dtoProduct)
        {
            foreach (DtoProduct p in this.listProduct)
            {
                if (dtoProduct.Idproduct.Equals(p.Idproduct) && dtoProduct.Name.Equals(p.Name))
                {
                    return true;
                }
            }
            return false;
        }

        private bool removefromlist(String tipo, int id, String name)
        {
            if (tipo.Equals("P"))
            {
                foreach (DtoProduct p in listProduct)
                {
                    if (p.Idproduct.Equals(id.ToString()) && p.Name.Equals(name))
                    {
                        listProduct.Remove(p);
                        return true;
                    }
                }
            }
            else if (tipo.Equals("L"))
            {
                foreach (DtoLine l in listLine)
                {
                    if (l.IdLine.Equals(id.ToString()) && l.Description.Equals(name))
                    {
                        listLine.Remove(l);
                        return true;
                    }
                }
            }
            return false;
        }
        private bool checkInsert()
        {
            return (dtoCustomer != null) && (listProduct.Count != 0 || listLine.Count != 0);
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkInsert())
            {
                int idFactura = Dominio.Invoices.getIdInvoice();
                //creamos la nueva factura
                string insertInvoice = "Insert into Invoices values ('" + idFactura + "',trunc(SYSDATE),'" + dtoCustomer.Idcustomer + "','" + acumuladortotalNeto + "','" + acumuladortotalIva + "',0)";
                GestorInvoices.insertInvoice(insertInvoice);

                foreach (DtoProduct p in listProduct)
                {
                    int amount = 0;
                    for (int i = 0; i < dgvInv.RowCount; i++)
                    {
                        String id = dgvInv.Rows[i].Cells[0].Value.ToString();
                        String name = dgvInv.Rows[i].Cells[2].Value.ToString();
                        if (p.Idproduct.Equals(id) && p.Name.Equals(name))
                        {
                            amount = Int32.Parse(dgvInv.Rows[i].Cells[3].Value.ToString());
                        }
                    }
                    String sql = "Insert into Invoices_Products values(0,'" + p.Idproduct + "','" + idFactura + "','" + amount + "','" + p.Price + "')";
                    GestorInvoicesProducts.insertInvoicesProduct(sql);
                }

                foreach (DtoLine l in listLine)
                {
                    String sql = "Insert into Lines values (0,'" + idFactura + "','" + l.Description + "','" + l.Quantity + "','" + l.Price + "')";
                    GestorLines.insertLine(sql);
                }
                Dispose();

            }
            else
            {
                MessageBox.Show(errorDialog() );
            }
        }
        private String errorDialog()
        {
            if (this.idioma == "ESPAÑOL")
            {
                String error = "Se han encontrado algunos errores: \n";
                if (dtoCustomer == null)
                {
                    error += "\t - Debe Selecionar un Cliente \n";
                }
                if (listLine.Count == 0 && listProduct.Count == 0)
                {
                    error += "\t - No hay datos para introduci \n";
                }

                return error;
            }
            else
            {
                String error = "Some Errors has been found: \n";
                if (dtoCustomer == null)
                {
                    error += "\t - you must Select a Customer \n";
                }
                if (listLine.Count == 0 && listProduct.Count == 0)
                {
                    error += "\t - There is no data in the table \n";
                }
                return error;
            }

        }
    }
}
