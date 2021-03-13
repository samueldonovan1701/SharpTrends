function corsPluginNotDetected()
{
    alert("Cross-Origin Request Failed\n"+
          "You must have a CORS extension installed"+
          " for this tool to function");
}

$(document).ready(() => {
	var url = "https://trends.google.com/trends/api/autocomplete/CORStest";

	$.get({url: url, dataType: "text"})
		.fail(corsPluginNotDetected);

});