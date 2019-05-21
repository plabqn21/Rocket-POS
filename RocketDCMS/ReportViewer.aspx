<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="RamsoftBD.ReportViewer" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="form1" runat="server">
        <asp:ScriptManager ID="RocketScriptManager" runat="server"></asp:ScriptManager>
    <div>
    
    </div>
        <rsweb:ReportViewer ID="ReportViewerDC" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="800px" Width=100%>
        </rsweb:ReportViewer>
    </form>
</body>
</html>
