<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="AndiTecnica.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Estilo/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../Estilo/CSS/style.css" rel="stylesheet" />
    <link href="../Estilo/CSS/font-awesome.css" rel="stylesheet" />
    <link href="../Estilo/CSS/animate.css" rel="stylesheet" />
    <link href="../Estilo/CSS/diseno_app.css" rel="stylesheet" />

    <title>AndiTecnica</title>
    <style type="text/css">
        .auto-style2 {
            width: 100px;
            height: 100px;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <table align="center" class="panel panel-primary" width="70%">
                <tr>
                    -
          <td>
              <table align="center" class="auto-style1">
                  <tr>
                      <td colspan="4">
                          <br />
                      </td>
                  </tr>
                  <tr>
                      <td rowspan="2" width="32%" align="center">
                          <img alt="" class="auto-style2" src="Imagenes/logo.png" /></td>
                      <td width="44%">
                          <asp:TextBox ID="txt_usuario" class="form-control" runat="server" placeholder="Usuario"></asp:TextBox>
                      </td>
                      <td width="4%">&nbsp;</td>
                      <td width="20%">
                          <asp:Button ID="btn_ingresar" runat="server" Text="Ingresar" class="input-btn" />
                      </td>
                      <td width="20%"></td>
                  </tr>
                  <tr>
                      <td>
                          <asp:TextBox ID="txt_contrasena" class="form-control" runat="server" placeholder="Contraseña" type="password"></asp:TextBox>
                      </td>
                      <td>&nbsp;</td>
                      <td></td>
                  </tr>
                  <tr>
                      <td colspan="4">
                          <br />
                      </td>
                  </tr>
              </table>
          </td>
                </tr>
            </table>
            <div class="alert alert-danger text-center" role="alert" runat="server" id="div_error" visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close" runat="server" id="btn_cerrarerror"><span aria-hidden="true">&times;</span></button>
                Error inciando sesion
            </div>
    </form>
</body>
</html>
