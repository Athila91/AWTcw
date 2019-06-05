<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<AWTcw.Models.QuestionModel>" %>

<!DOCTYPE html>
<%: Styles.Render("~/Content/css") %>
<%: Scripts.Render("~/bundles/modernizr") %>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Home</title>
    
    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#postq").click(function () {
                $.post("/PostQuestions/CheckUser", function (returndata) {
                    if (returndata == false) {
                        //data: { componentID: componentID },
                        //type: "GET",
                        //async: false,
                        //dataType: "json",
                        //success: function (data) {
                        //    if (data == false) {
                        window.alert("Please login to post a question");
                    }
                    else {
                        window.location = "/PostQuestions/PostQuestions"

                         }
                        
            });
        });
        
       
            //$.getJSON('/Api/search/Get', function (data) {
            //    var items = [];
            //    $.each(data, function (key, val) {
            //        var jsonContent = val.Title;
            //        var content = $("<li id=" + val.QuestionId + "><label>" + "Answers : " + val.NoOfAnswers + "</Label>" + "&nbsp;&nbsp;&nbsp;&nbsp&nbsp;" + "<a id=" + val.QuestionId + " href='Test'>" + jsonContent + "</a></li");
            //        $("#sz").append(content);
            //    });
            //});
            $.ajax({
                url: "/Api/search/Get",
                //data: { componentID: componentID },
                type: "GET",
                async: false,
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    if (data.length > 0) {
                        $.each(data, function (key, val) {
                            var jsonContent = val.Title;
                            var content = $("<li><label>" + "Answers : " + val.NoOfAnswers + "</Label>" + "&nbsp;&nbsp;&nbsp;&nbsp&nbsp;" + "<a id=" + val.QuestionId + "></a></li");
                            //var dataType = self._resolveDataTypeByCode(item.DataType);
                            //var rawObject = { id: idParam, key: keyParam, text: keyParam, type: dataType };
                            //paramList.push(rawObject);
                            $("#questionlist").append(content);
                            $("#" + val.QuestionId).text(jsonContent);
                            $("#" + val.QuestionId).attr("href", '/ViewAnswers/ViewAnswers/?quesid=' + val.QuestionId);
                        });
                    }
                    $("#Button2").click(function () {
                        var s = $('#TextSearch').val();
                        $.ajax({
                            url: "/Api/search/questions",
                            data: { s: s },
                            type: "GET",
                            async: false,
                            dataType: "json",
                            success: function (data) {
                                $("#questionlist").empty();
                                //console.log(data);
                                if (data.length > 0) {
                                    $.each(data, function (key, val) {
                                        var title = val.Title;
                                        var content = $(" <li><label>" + "Answers : " + val.NoOfAnswers + "</Label>" + "&nbsp;&nbsp;&nbsp;&nbsp&nbsp;" + "<a id=" + val.QuestionId + "></a></li>");
                                        $("#sz").append(content);
                                        $("#" + val.QuestionId).text(title);
                                        $("#" + val.QuestionId).attr("href", '/ViewAnswers/ViewAnswers/?quesid='+val.QuestionId);
                                    });
                                }
                            },
                            //$("#Button2").click(function () {
                            //    var txId = $('#Text1').val();
                            //    $.getJSON('/Api/search/questions/?s=' + txId, function (data) {
                            //        var items = [];
                            //        $("#sz").empty();
                            //        $.each(data, function (key, val) {
                            //            var title = val.Title;
                            //            //var Body  = val.Question;
                            //            var checkboxSelector = "input:checkbox";

                            //            var content = $(" <li><label>" + "Answers : " + val.NoOfAnswers + "</Label>" + "&nbsp;&nbsp;&nbsp;&nbsp&nbsp;" + "<a id=" + val.QuestionId + "></a></li>");
                            //            //var con = $("<li><Label>" + Body + "</Label></li>");
                            //            $("#sz").append(content);
                            //            $("#" + val.QuestionId).text(title);
                            //            $("#" + val.QuestionId).attr("href", '/ViewAnswers/ViewAnswers/?quesid='+val.QuestionId);
                            //        });
                            //    });
                            //});
                            //$("#Button2").click(function () {
                            //    var txId = $('#Text1').val();
                            //    $.getJSON('/Api/search/questions/?s=' + txId, function (data) {
                            //        var items = [];
                            //        for (var i in data)
                            //            items.push([data[i].QuestionId, data[i].Title, data[i].Question]);
                            //        //$("#sz").empty();
                            //        $('#gridData').dataTable({
                            //            "aaData": items,
                            //            "aoColumns": [
                            //                { "sTitle": "QuestionId" },
                            //                { "sTitle": "Title" },
                            //                { "sTitle": "Question" }
                            //            ]
                            //        });
                            //$.each(data, function (key, val) {
                            //    var title = val.Title;
                            //    var Body = val.Question;
                            //    var id = val.QuestionId;
                            //    var checkboxSelector = "input:checkbox";

                            //    var content = $(" <li><a id=" + val.QuestionId + "></a></li>");
                            //    //var con = $("<li><Label>" + Body + "</Label></li>");
                            //    $("#sz").append(content);
                            //    $("#" + val.QuestionId).text(title);
                            //    $("#" + val.QuestionId).attr("href", "/ViewAnswers/ViewAnswers", { "quesid": val.QuestionId, "title": val.Title, "body": val.Question });
                            //    });
                            //});

                            //$("#sz li").click(function () {
                            //    //alert(this.id); // id of clicked li by directly accessing DOMElement property
                            //    //alert($(this).attr('id')); // jQuery's .attr() method, same but more verbose
                            //    //alert($(this).html()); // gets innerHTML of clicked li
                            //    //alert($(this).text()); // gets text contents of clicked li
                            //    alert($('ul#sz li').attr('id'));
                            //});
                        });
                    }
                    )
                }
            });


        });</script>
    <style type="text/css">
        .pullLeft {
            float: left;
        }

        .pullRight {
            float: right;
        }

        .mainContainer {
            width: 1200px;
            margin: 20px auto;
        }

        .navLinks a {
            margin-right: 140px;
        }
        .clearBoth {
            clear:both;
        }
        #sz {
            height: 39px;
        }
    </style>
</head>
<body>
    <div id="header" style="background-color: #726f6f; height: 70px">
        <div style="width: 100px; margin-left: 1000px; height:25px; margin-top:10px; border-style: solid; background-color: #aea6a6; text-align: center; position:absolute; font-size:larger">
            <%: Html.ActionLink("Log Out","Login","Login")%>
           <%--<%: Html.ActionLink("My Profile","UserProfile","UserProfile")%>--%>
        </div>
        <div style="width: 100px; margin-left: 1150px; margin-top:10px; height:25px; border-style: solid; background-color: #aea6a6; text-align:center; position:absolute; font-size:larger"> <%: Html.ActionLink("My Profile","UserProfile","UserProfile")%></div>
       <%-- <p style="width: 80px; margin-left: 1100px; margin-top:0px; border-style: solid; background-color: #aea6a6; text-align: center; position:absolute">
            <%: Html.ActionLink("My Profile","UserProfile","UserProfile")%>
        <%--<link id="profile" href="/UserProfile/UserProfile" rel="next" style="style=width: 80px; margin-left: 1000px;"/>--%>

        <%--</p>--%>
    </div>
    <div class="mainContainer">
        <div class="navigation">
            <div class="navLinks pullLeft">
                <a id="postq" style="width:90px; font-size:x-large" href="#">Post Questions</a>
                <a href="/Tag/Tag" style="width:90px; font-size:x-large">Tags</a>
                <a href="/Category/Category" style="width:90px; font-size:x-large">Categories</a>
                <a href="/Questions/Questions" style="width:90px; font-size:x-large">Questions</a>
            </div>
            <div class="pullRight">
                <div> <input type="text" name="query" id="TextSearch" style="font-size:large" /></div>
               <div>
                <input type="button" id="Button2" value="Search" style="width:80px; font-size:large" />
                   </div>
            </div>
        </div>
        <div class="clearBoth"></div>
        <div>

            <ul id="questionlist" style="font-size: x-large;" class="aaa">

            </ul>
            <table  border="0" class="display" id="gridData"></table>
        </div>
    </div>



    <%--<div style="margin-top:20px">--%>
    <%--<div style="margin-top: 20px; margin-left: 30px"><%: Html.ActionLink("Questions","Questions","Questions") %></div>--%>


    <%--<%: Html.ActionLink("Ask Question","Questions","Questions") %>--%>
    <%--<%: Html.ActionLink("Questions","Questions","Questions") %>--%>
    <%--<input type="text" name="query1" id="query" style="height: 25px; font-size: 12px; width: 176px; margin-left: 1100px" />--%>
    <%--<button name="Search" id="Button1" type="submit" value="submit" style="width: 80px; margin-left: 20px; font-size: 12px; font-family: Arial, Helvetica, sans-serif; font-weight: normal;"/>--%>
    <%--<input type="button" id="Button1" value="Search" />--%>


    <%: Scripts.Render("~/bundles/jquery") %>
</body>
</html>
