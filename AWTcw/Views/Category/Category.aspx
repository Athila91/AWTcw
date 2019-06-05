<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<AWTcw.Models.CategoryModel>" %>

<!DOCTYPE html>
<%: Styles.Render("~/Content/css") %>
<%: Scripts.Render("~/bundles/modernizr") %>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Category</title>
</head>
<body>
     <div id="header" style="background-color: #726f6f; height: 70px">
        <div style="width: 100px; margin-left: 1000px; height:25px; margin-top:10px; border-style: solid; background-color: #aea6a6; text-align: center; position:absolute; font-size:larger">
            <%: Html.ActionLink("Log Out","Login","Login")%>
          
        </div>
        <div style="width: 100px; margin-left: 1150px; margin-top:10px; height:25px; border-style: solid; background-color: #aea6a6; text-align:center; position:absolute; font-size:larger"> 
            <%: Html.ActionLink("My Profile","UserProfile","UserProfile")%>

        </div>
   
    </div>
    <div><label style="margin-left:550px; font-size:xx-large">Categories</label></div>
    <ul style="font-size: x-large; margin-left:30px; margin-top:40px;">
     <%foreach (AWTcw.Models.CategoryModel a in ViewBag.lis)
                 {%>
        <li><label>No. Of questions:&nbsp; <%: a.NoOfQuestions %></label>&nbsp;&nbsp;&nbsp;&nbsp;<%: Html.ActionLink(a.Name, "CategoryQuestions", "Questions", new { category = a.Name },null)%> </li>
                <%--<li><label><%: a.NoOfQuestions %></label><a id="<%: a.Name %>" href="/Questions/CategoryQuestions/?category="><%: a.Name %></a> </li>--%>
                <%} %>
            </ul>
    <div>
        
    </div>
     <%: Scripts.Render("~/bundles/jquery") %>
</body>
</html>
