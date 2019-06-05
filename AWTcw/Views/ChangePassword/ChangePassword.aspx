<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<AWTcw.Models.ChangePasswordModel>" %>

<!DOCTYPE html>
<%: Styles.Render("~/Content/css") %>
<%: Scripts.Render("~/bundles/modernizr") %>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>ChangePassword</title>
</head>
<body>
     <div id="header" style="background-color: #726f6f; height: 70px">
        <div style="width: 100px; margin-left: 1000px; height:25px; margin-top:10px; border-style: solid; background-color: #aea6a6; text-align: center; position:absolute; font-size:larger">
            <%: Html.ActionLink("Log Out","Login","Login")%>
           <%--<%: Html.ActionLink("My Profile","UserProfile","UserProfile")%>--%>
        </div>
        <div style="width: 100px; margin-left: 1150px; margin-top:10px; height:25px; border-style: solid; background-color: #aea6a6; text-align:center; position:absolute; font-size:larger"> <%: Html.ActionLink("My Profile","UserProfile","UserProfile")%></div>
       </div>
     <div><label style="margin-left:550px; font-size:xx-large">Change Password</label></div>
    <% using (Html.BeginForm("UpdatePassword", "ChangePassword"))
       { %>
    <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
    
        <fieldset style="margin-top:100px; margin-left:30px;font-size:x-large">
            <legend>Change Password</legend>
    
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.OldPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.OldPassword) %>
                <%: Html.ValidationMessageFor(model => model.OldPassword) %>
            </div>
             <div class="editor-label">
                <%: Html.LabelFor(model => model.NewPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.NewPassword) %>
                <%: Html.ValidationMessageFor(model => model.NewPassword) %>
            </div>
    
    
           
   
             <div class="editor-label">
                <%: Html.LabelFor(model => model.ConfirmPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.ConfirmPassword) %>
                <%: Html.ValidationMessageFor(model => model.ConfirmPassword) %>
            </div>
           
            
            <p>
                <input type="submit" value="Save" style="width:60px; font-size:large;background-color: #3366FF" />
            </p>
        </fieldset>
    <% } %>
    <div>
        
    </div>
     <%: Scripts.Render("~/bundles/jquery") %>
</body>
</html>
