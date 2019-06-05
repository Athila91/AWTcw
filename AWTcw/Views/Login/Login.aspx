<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<AWTcw.Models.UserModel>" %>


<%--<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log in
</asp:Content>--%>

<%--<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Log in.</h1>
    </hgroup>--%>

    <%--<section id="loginForm" aria-hidden="false">
    <h2>Use a local account to log in.</h2>
    <%using (Html.BeginForm("ValidateUser", "Login"))
      { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>

        <div>
        <fieldset>
            <legend>Log in Form</legend>
            <ol>
                <li>
                    <%: Html.LabelFor(m => m.Email) %>
                    <%: Html.TextBoxFor(m => m.Email) %>
                    <%: Html.ValidationMessageFor(m => m.Email) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.LoginPassword) %>
                    <%: Html.PasswordFor(m => m.LoginPassword) %>
                    <%: Html.ValidationMessageFor(m => m.LoginPassword) %>
                </li>
                <li>
                    <%: Html.CheckBoxFor(m => m.IsLoggedin) %>
                    <%: Html.LabelFor(m => m.IsLoggedin, new { @class = "checkbox" }) %>
                </li>
            </ol>
            <input type="submit" value="Log in" />
    
        </fieldset>
            </div>
        <p>
            <%: Html.ActionLink("Sign Up","SignUp","SignUp")%> if you don't have an account.
        </p>
    <% } %>
    </section>--%>

   <%-- <section class="social" id="socialLoginForm">
        <h2>Use another service to log in.</h2>
        <%: Html.Action("ExternalLoginsList", new { ReturnUrl = ViewBag.ReturnUrl }) %>
    </section>--%>
<%--</asp:Content>--%>

<%--<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>--%>



<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Login</h2>

</asp:Content>--%>

<%--<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    knkn
</asp:Content>--%>

<%--<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
<%--</asp:Content>--%>

<!DOCTYPE html>
<%: Styles.Render("~/Content/css") %>
        <%: Scripts.Render("~/bundles/modernizr") %>



<html>
     
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>
</head>
    
        <body>
    <div id="c" style="background-color:#726f6f; height:70px">
        <div style="width: 90px; margin-left: 1100px; border-style:solid; font-size:large; background-color:#aea6a6; margin-top:10px; text-align:center; position:absolute">
            
            <%: Html.ActionLink("Sign Up","SignUp","SignUp")%>

        </div>
     
        <div style="width: 90px; margin-left: 100px; border-style:solid; font-size:large; background-color:#aea6a6; margin-top:10px; text-align:center; position:absolute">
            
            <%: Html.ActionLink("Home","Home","Home")%>
        </div>
        </div>
           
            <p>
                <br />
            </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p style="margin-left: 781px">
                &nbsp;</p>
    
    <%using (Html.BeginForm("ValidateUser", "Login"))

        
      { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true,"The user name or password provided is incorrect.") %>

        <div id="az" style="width: 548px; margin-left: 800px; color: #1606e8; height: 137px; background-color:#cfcbcb" >
        <fieldset style="background-color:#cfcbcb">
            <legend style="font-size:xx-large">Log in Form</legend>
            <ul style="font-size: x-large; color:#110f0f">
                <li>
                    <div>
                    <%: Html.LabelFor(m => m.Email) %>
                        </div>
                    <%: Html.TextBoxFor(m => m.Email) %>
                    <%: Html.ValidationMessageFor(m => m.Email) %>
                </li>
                <li>
                     <div>
                    <%: Html.LabelFor(m => m.LoginPassword) %>
                         </div>
                    <%: Html.PasswordFor(m => m.LoginPassword) %>
                    <%: Html.ValidationMessageFor(m => m.LoginPassword) %>
                </li>
               
            </ul>
            <input type="submit" value="Log in" class="loginbut" style="background-color: #3366FF; font-size: large;"/>
    
        </fieldset>
            </div>
       <div style="width:548px; background-color:#d1caca ; height: 200px; margin-left: 30px; margin-top:-100px ;  position:absolute; text-align:justify; font-size:large; color:#110f0f"><label runat="server">
           C#Q&A is a question and answer site for professional and programmers
            who are interested in programming in C# language. It's built and run by you. While you can 
           get help on the problems you have in C# programming you can also share your knowledge with 
           others by answering to the questions. To post questions and answers you have to login to the s
           ite. Without logging in only you can do is check the posts that are already there. </label></div>
    <% } %>
              <%: Scripts.Render("~/bundles/jquery") %>
   </body>
</html>
    