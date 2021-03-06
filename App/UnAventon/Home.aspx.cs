﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnAventon
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }       

        protected void idInciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                //divErrorLogin.Visible = false;
                Page.Validate("GroupLogin");
                if (Page.IsValid)
                {
                    //Obtengo las credenciales del usuario.
                    var username = tbEmail.Text;
                    var password = tbPassword.Text;

                    Bol.Usuario user = new Bol.Usuario();
                    user = user.IsAuthenticateUser(username, password);

                    //Si el Usuario no es Null autentico.
                    if (user != null && user.Id > 0)
                    {
                        //Armo el ticket.
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                                                                         user.Email,
                                                                                         DateTime.Now,
                                                                                         DateTime.Now.AddMinutes(120),
                                                                                         false,
                                                                                         username,
                                                                                         FormsAuthentication.FormsCookiePath);

                        string hash = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                        Response.Cookies.Add(cookie);

                        //Guardo el usuario en el Context.
                        Context.Items.Remove("Usuario");
                        Context.Items.Add("Usuario", user);

                        String r = Request.QueryString["ReturnUrl"];
                        //Response.Redirect("~/Viajes/Listado-de-Viajes.aspx");
                        Response.Redirect(r != null ? Request.QueryString["ReturnUrl"].ToString() : "~/Viajes/Listado-de-Viajes.aspx", false);
                    }
                    else throw new Exception("Usuario o contraseña incorrectos. ");
                }
            }
            catch (Exception ex)
            {
                tbEmail.CssClass = "form-control error";
                tbPassword.CssClass = "form-control error";

                HtmlGenericControl divMsjAlerta = (HtmlGenericControl)Page.FindControl("divMsjAlerta");
                Literal liMensajeAlerta = (Literal)Page.FindControl("liMensajeAlerta");
                liMensajeAlerta.Text = ex.Message;
                divMsjAlerta.Visible = true;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuario/alta-Usuario.aspx");
        }

        protected void cvPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbEmail.CssClass = "form-control";
            cvEmail.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                args.IsValid = false;                
                tbEmail.CssClass = "form-control error";
                cvPassword.ErrorMessage = "Usuario o contraseña incorrectos. ";
            }
        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            tbPassword.CssClass = "form-control";
            cvPassword.ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                args.IsValid = false;
                tbPassword.CssClass = "form-control error";
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Viajes/Listado-de-Viajes-Publico.aspx");
        }

        protected void lbRecuperarCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuario/RecuperarCuenta.aspx");
        }
    }
}