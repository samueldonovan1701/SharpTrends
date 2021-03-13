function tieOnCopyOnClick()
{
  $("#mid-table tbody tr").each((index, element) => {
    $(element).click(() => {
      var text = element.children[2].innerText;
      copyToClipboard(text);
      
      $("#copy-notification").removeClass("hide");
      setTimeout(() => $("#copy-notification").addClass("hide"), 2000);
    });

    $(element).contextmenu((e) => { //right click
      var name = element.children[0].innerText;
      var type = element.children[1].innerText;
      var mid = element.children[2].innerText;
      copyToClipboard("new Topic(\""+mid+"\", \""+name+"\", \""+type+"\");");
      
      $("#copy-notification").removeClass("hide");
      setTimeout(() => $("#copy-notification").addClass("hide"), 2000);
    });
  });
}

function setTableData(data)
{
  $("#mid-table tbody tr").remove(); //Clear table body 
  
  var tablebody = $("#mid-table tbody");
  
  data.forEach((item) => {
    tablebody.append("<tr><td>"+item.title+"</td><td>"+item.type+"</td><td>"+item.mid+"</td></tr>");
  });
  
  if(data.length == 0)
    tablebody.append("<tr><td>No Results</td><td></td><td></td></tr>");
  else if(data.length != 1)
    tieOnCopyOnClick();
}



$(document).ready(() => {
  $("#input-box").on('change', (e) => {
    if(e.target.value.length > 1)
    { //Get
        var url = "https://trends.google.com/trends/api/autocomplete/" + encodeURIComponent(e.target.value);
        $.get({url: url, dataType: "text"})
          .done((text) => {
            text = text.substring(6);
            try{
              var data = JSON.parse(text).default.topics;
              setTableData(data);
            } catch(e)
            {
              alert("Error: Too many requests");
            }
          })
          .fail((jqXHR, textStatus, errorThrown) => {
            corsPluginNotDetected();
          });
    }
  });
});
