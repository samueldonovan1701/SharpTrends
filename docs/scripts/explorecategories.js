function tieOnOnClick()
{
  $("#id-table tbody tr").each((index, element) => {
    $(element).click(() => {
      var text = element.children[1].innerText;
      copyToClipboard(text);
      
      $("#copy-notification").removeClass("hide");
      setTimeout(() => $("#copy-notification").addClass("hide"), 2000);
    });

    $(element).contextmenu((e) => { //right click
      var description = element.children[0].innerText;
      var id = element.children[1].innerText;
      copyToClipboard("new ExploreCategory("+id+", \""+description+"\");");
      
      $("#copy-notification").removeClass("hide");
      setTimeout(() => $("#copy-notification").addClass("hide"), 2000);
    });
  });
}

function tableRowAddChildren(tablebody, parentElement, childrenData, depth)
{
	childrenData.forEach((data) => {
		if(data.children != null)
		{
			var elem = $("<tr><td style=\"padding-left:"+(depth*2)+"em\">"+data.name+"</td><td>"+data.id+"</td></tr>");
			tablebody.append(elem);
			tableRowAddChildren(tablebody, elem, data.children, depth+1);
		}
		else
		{
			tablebody.append("<tr><td style=\"padding-left:"+(depth*2)+"em\">"+data.name+"</td><td>"+data.id+"</td></tr>");
		}
	});
}

function setTableData(data)
{
  $("#id-table tbody tr").remove(); //Clear table body 
  
  var tablebody = $("#id-table tbody");
  
  var top = $("<tr><td>All categories</td><td>0</td></tr>");
  tablebody.append(top);
  tableRowAddChildren(tablebody, top, data.children, 1);
  tieOnOnClick();
}

$(document).ready(()=>{
	$.get({url: "https://trends.google.com/trends/api/explore/pickers/category?hl=en-GB&tz=0", dataType: "text"})
	.done((text) => {
    	text = text.substring(5);
    	var data = JSON.parse(text);
    	setTableData(data);
    })
    .fail((jqXHR, textStatus, errorThrown) => {
        corsPluginNotDetected();
  	});
});