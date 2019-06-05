<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<AWTcw.Models.UserModel>" %>

<!DOCTYPE html>


<%: Styles.Render("~/Content/css") %>
        <%: Scripts.Render("~/bundles/modernizr") %>
<html>
    <body>
        <%: Styles.Render("~/Content/css") %>
<%: Scripts.Render("~/bundles/modernizr") %>
         <div id="header" style="background-color: #726f6f; height: 70px">
        <div style="width: 100px; margin-left: 1000px; height:25px; margin-top:10px; border-style: solid; background-color: #aea6a6; text-align: center; position:absolute; font-size:larger">
            <%: Html.ActionLink("Log Out","Login","Login")%>
          
        </div>
             </div>
      
<%--<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>--%>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <section id="registerform">
<%--<h2>Register</h2>--%>
      <%using (Html.BeginForm("CreateUser", "SignUp")) 
      { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
        <%--<div class="validation-summary-errors" style="margin-top: 121px">--%>
        <%--<div id="ac" style="margin-left: 27px; margin-top: 160px; ">--%>
        <fieldset id="ac" style="margin-left: 27px; margin-top: 160px;">
            <legend>Registration Form</legend>
            <ol>
                <li>
                    <div>
                    <%: Html.LabelFor(m => m.FirstName) %>
                        </div>
                    <%: Html.TextBoxFor(m => m.FirstName) %>
                    <%: Html.ValidationMessageFor(m => m.FirstName)%>
                </li>
                <li>
                    <div>
                    <%: Html.LabelFor(m => m.LastName) %>
                        </div>
                    <%: Html.TextBoxFor(m => m.LastName)%>
                    <%: Html.ValidationMessageFor(m => m.LastName)%>
                </li>
                <li>
                    <div>
                    <%: Html.LabelFor(m => m.Email) %>
                    </div>
                    <%: Html.TextBoxFor(m => m.Email , new {id = "ddd" }) %>
                    <%: Html.ValidationMessageFor(m => m.Email) %>
                </li>
                 <li>
                    <%: Html.Label("User Type") %>
                    <%: Html.DropDownList("t")%>
                </li>
                <li>
                    <div>
                    <%: Html.LabelFor(m => m.Password) %>
                    </div>
                    <%: Html.TextBoxFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </li>
                <li>
                    <div>
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                    </div>
                    <%: Html.TextBoxFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </li>
            </ol>
            <input type="submit" value="Sign Up" id="regsubmit">
   
        </fieldset>
         
            <%--</div>--%>
        <% } %>
        
        <script src="../../Scripts/jquery-1.7.1.min.js"></script>
        <script>
            $(document).ready(function () {
                $("#ddd").focusout(function () {
                    var tex = $(this).val();
                    //window.alert(tex);
                    $.post("/SignUp/CheckEmail", { "t": tex }, function (statusReply) {
                        if (statusReply == true) {
                        }
                        else {
                            window.alert("Email aready exist.") ;
                        }
                    });

                });
                //$.post("/SignUp/CreateUser",  function (statusReply) {
            });    //    window.alert(statusReply.Message + " " + statusReply.Data);
                    //    var message = '@message';
                    //    if (message)
                    //        alert(message);
</script>
           <%: Scripts.Render("~/bundles/jquery") %>
            </body>
</html>