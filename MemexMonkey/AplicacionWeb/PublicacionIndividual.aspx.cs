﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeb
{
    public partial class PublicacionIndividual : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                int idImagen = 0;

                string id = Page.RouteData.Values["idImagen"].ToString();

                if (int.TryParse(id, out idImagen))

                    CargarCaracteristicas(idImagen);

            }

        }


        // TODO Pendiente rellenar con la informacion correspondiente.

        private void CargarCaracteristicas ( int idImagen )
        {

            Entidades.Imagenes imagenes = new Entidades.Imagenes();

            List < Entidades.Imagenes > listaImagen = imagenes.ObtenerPorIdImagen ( idImagen );

            if ( listaImagen.Count == 1 )
            {

                string idCategoria = listaImagen[0].IdCategoria.ToString(); ;

                string userId = listaImagen[0].UserId.ToString();

                string esAprobado = listaImagen[0].EsAprobado.ToString();

                string titulo = listaImagen[0].Titulo;

                string directorioRelativo = listaImagen[0].DirectorioRelativo.ToString();

                string rutaRelativa = listaImagen[0].RutaRelativa.ToString();

                string enlaceExterno = listaImagen[0].EnlaceExterno.ToString();

                string etiquetasBasicas = listaImagen[0].EtiquetasBasicas.ToString();

                string etiquetasOpcionales = listaImagen[0].EtiquetasOpcionales.ToString();

                string fechaSubida = listaImagen[0].FechaSubida.ToString();

                string fechaPublicacion = listaImagen[0].FechaPublicacion.ToString();
                
                // TODO Faltan poner los demas parametros.

                uiTituloImagen.InnerText = titulo;

                uiUsuarioAportador.InnerText = userId;

                uiFechaPublicacion.InnerText = fechaPublicacion;

                uiImagenIndividual.Src = rutaRelativa;

                uiEtiquetas.InnerText = string.Format ( "{0} | {1}", etiquetasBasicas, etiquetasOpcionales );

                uiPluginComentariosFacebook.Attributes.Add ( "data-href", string.Format ( "{0}{1}", "http://monkey.somee.com/PublicacionIndividual/", idImagen ) );

            }
            else if ( listaImagen.Count != 1 )
            {
                
                string script = @"<script type='text/javascript'> alert('{0}'); </script>";

                script = string.Format ( script, "Esta publicacion no pudo ser cargada :(" );

                ScriptManager.RegisterStartupScript ( this, typeof ( Page ), "Alerta", script, false );

                Response.Redirect ( "~/Default.aspx" );

            }

        }

    }
}