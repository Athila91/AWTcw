<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<AWTcw.Models.QuestionModel>" %>

<!DOCTYPE html>
<%: Styles.Render("~/Content/css") %>
<%: Scripts.Render("~/bundles/modernizr") %>
<html>
<head runat="server">
    <link href="../../Content/tagit.ui-zendesk.css" rel="stylesheet" />
    <link href="../../Content/jquery.tagit.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" />
    <title>ViewAnswers</title>
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
     <div><label style="margin-left:550px; font-size:xx-large">View Question</label></div>
    <fieldset style="font-size: x-large; margin-left:30px; margin-top:40px;">
        <legend>Question Details</legend>
        
            <div>
           <input type="checkbox" id="loyaltychkbox"/>     
        <%: Html.DisplayFor(q => q.Title) %></div>
        <div>
         <%: Html.DisplayFor(q => q.Question) %></div>
       
           <% foreach (AWTcw.Models.TagModel tag in  Model.tags) {%>
           <%: Html.ActionLink(tag.TagName, "TagQuestions", "Questions", new { tag = tag.TagName },null)%>
            <%} %>
       
        <ul id="a">
               <%foreach (AWTcw.Models.AnswerModel a in ViewBag.S)
                 {%>
        
                <li><input type="checkbox" id="<%:a.UserId %>" class="checkboxes" /><label><% =a.AnswerText%> </label></li>
                <%} %>
            </ul>
        <input type="text" id="ans" />
        <input type="button" id="but" value="Add Answer" />
      
    </fieldset>
    <p>
    </p>
     <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script>
    <script src="../../Scripts/tag-it.min.js"></script>
    
    <script>
        $(document).ready(function () {
            $(".checkboxes").change(function () {
                var userid = $(this).attr("id");
                if ($(this).is(":checked")) {
                    $.post("/ViewAnswers/AddReputation", { "rep": userid }, function (returndata) {
                        if (returndata == false) {
                            window.alert("You must Login to add a vote");
                            $('#' + userid).prop('checked', false);
                        }
                    });
                }

            });



            $("#loyaltychkbox").change(function () {

                if ($(this).is(":checked")) {
                    $.post("/ViewAnswers/LoyaltyPoints", function (returndata) {
                        if (returndate == false) {
                            window.alert("Please login to add a vote");
                        }

                    });
                }
            });





            $("#but").click(function () {
                var txId = $('#ans').val();
                $.post("/ViewAnswers/AddAnswer", { "ans": txId }, function (statusReply) {
                    if (statusReply == false) {
                        window.alert("Please login to add an answer");
                    }

                });
            });
            $('#myTags').tagit();
            //$("#ddd").focusout(function () {
            //    var tex = $(this).val();
            //    //window.alert(tex);
            //    $.post("/SignUp/CheckEmail", { "t": tex }, function (statusReply) {
            //        if (statusReply == true) {
            //        }
            //        else {
            //            window.alert("dddd");
            //        }
            //    });
        });
                       
 </script>
</body>
</html>
