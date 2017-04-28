﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class InventarioControl
    {
        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        //ATRIBUTOS DE LA CLASE
        private Producto productInicio;
        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        //CONSTRUCTOR DE LA CLASE INVENTARIOCONTROL
        public InventarioControl()
        {
            this.productInicio = null;  //se inicializa el contador en cero
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        //METODO AGREGAR 
        public void Agregar(Producto newProduct)
        {
            if (productInicio == null)
                productInicio = newProduct;
            else
            {
                Producto temp = productInicio;

                if (newProduct.codigo < temp.codigo)
                {
                    newProduct.siguiente = temp;
                    productInicio = newProduct;
                }
                else
                    Agregar(temp, newProduct);
            }
        }
        private void Agregar(Producto temp, Producto nuevo)
        {
            if (temp.siguiente != null)
            {
                if (nuevo.codigo < temp.siguiente.codigo)
                {
                    nuevo.siguiente = temp.siguiente;
                    temp.siguiente = nuevo;
                }
                else
                    Agregar(temp.siguiente, nuevo);
            }
            else
                temp.siguiente = nuevo;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        //METODO BUSCAR
        public Producto Buscar(int codigo)
        {
            Producto temp = null;

            if (productInicio != null)
            {
                temp = productInicio;
                while (temp != null && temp.codigo < codigo)
                {
                    if (temp.codigo != codigo)
                        temp = temp.siguiente;
                }
            }
            return temp;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        //METODO BORRAR 
        public void Borrar(int codigo)
        {
            Producto temp = null;

            if (productInicio != null)
            {
                temp = productInicio;

                if (temp.codigo == codigo)
                {
                    productInicio = temp.siguiente;
                    temp = null;
                }
                else
                    Borrar(temp, codigo);
            }
        }
        private void Borrar(Producto temp, int codigo)
        {
            if (temp.siguiente != null && temp.siguiente.codigo <= codigo)
            {
                if (temp.siguiente.codigo == codigo)
                    temp.siguiente = temp.siguiente.siguiente;
                else
                    Borrar(temp.siguiente, codigo);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        //METODO INSERTAR
        public void Insertar(Producto newProduct, byte posicion)
        {
            Producto temp = null;
            int contador = 1;

            if (productInicio != null)
            {
                temp = productInicio;

                if (posicion == 1)
                {
                    newProduct.siguiente = temp;
                    productInicio = newProduct;
                }
                else
                    Insertar(newProduct, temp, posicion, contador);
            }
        }
        private void Insertar(Producto nuevo, Producto temp, int posicion, int cont)
        {
            if (temp != null)
            {
                if (posicion - 1 == cont)
                {
                    nuevo.siguiente = temp.siguiente;
                    temp.siguiente = nuevo;
                }
                else
                {
                    cont++;
                    Insertar(nuevo, temp.siguiente, posicion, cont);
                }
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        //METODO REPORTE
        public string Reporte()
        {
            //se crea una variable string
            string reporte = string.Empty;

            Producto temp = productInicio;

            while (temp != null)
            {
                reporte += temp.ToString();
                temp = temp.siguiente;
            }
            return reporte; // se retorna el reporte con las caracteristicas de todos los productos
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        //METODO REPORTE INVERSO
        public string reporteInverso()
        {
            Producto temp = productInicio;

            if (temp == null)
                return "Sin reporte";
            else
                return reporteInverso(temp);
        }
        private string reporteInverso(Producto temp)
        {
            if (temp.siguiente == null)
                return temp.ToString();
            else
                return reporteInverso(temp.siguiente) + temp.ToString();
        }
    }
}
