<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<AWTcw.Models.UserModel>" %>

<!DOCTYPE html>
<%: Styles.Render("~/Content/css") %>
<%: Scripts.Render("~/bundles/modernizr") %>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>UserProfile</title>
</head>
<body>

    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>
    <div><label style="margin-left:550px; font-size:xx-large">My Profile</label></div>
    <div id="header" style="background-color: #726f6f; height: 70px">
        <div style="width: 100px; margin-left: 1000px; height:25px; margin-top:10px; border-style: solid; background-color: #aea6a6; text-align: center; position:absolute; font-size:larger">
            <%: Html.ActionLink("Log Out","Login","Login")%>
        
        </div>
     
    </div>
    <% using (Html.BeginForm("SaveProfile", "UserProfile"))
       { %>
        <%: Html.ValidationSummary(true) %>
    
        <fieldset style="margin-top:100px; margin-left:30px;font-size:x-large">
            <legend>User Profile</legend>
    
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FirstName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.FirstName) %>
                <%: Html.ValidationMessageFor(model => model.FirstName) %>
            </div>
             <div class="editor-label">
                <%: Html.LabelFor(model => model.LastName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.LastName) %>
                <%: Html.ValidationMessageFor(model => model.LastName) %>
            </div>
    
    
           
   
             <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
           
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Reputation) %>
                <%: Html.DisplayFor(model => model.Reputation) %>
            </div>
               
            
             <div class="editor-label">
                <%: Html.LabelFor(model => model.LoyaltyPoints) %>
                 <%: Html.DisplayFor(model => model.LoyaltyPoints) %>
            </div>
           
            <div class="editor-label">
                <%: Html.ActionLink("Change Password", "ChangePassword", "ChangePassword") %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    <% } %>
    
</body>
</html>
