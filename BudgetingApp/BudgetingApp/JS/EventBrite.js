
{

    ViewBag.Title = "eventBrite";
}




    

    <script src="https://code.jquery.com/jquery-3.4.1.js"></script>

    
$(document).ready(GetEvents());

(function ($) {
    function GetEvents() {

        $.ajax({
            url: 'https://eventbriteapi.com/v3/events/search/?token=BJQ5NU5V6KLU3BZ7R32V&expand=venue&location.within=10km&location.address=Milwaukee&sort_by=distance&categories=103',
            dataType: 'json',
            type: 'get',

            success: function (data) {
                console.log(data);
                let events = data.event;
                for (let el in events) {
                    $("#MyTable").append(
                        `<tr>
                            <td> ${events[el].name.text} </td>
                            <td> ${events[el].description.text} </td>
                            <td> ${events[el].url.text} </td>

                        </tr>`)
                }


            },
            //error: {
            //    console.log("error")
            //},

        });
    }
})(JQuery);