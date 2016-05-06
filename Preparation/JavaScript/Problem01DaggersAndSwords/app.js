function solve(arr) {
    console.log("<table border=\"1\">");
    console.log("<thead>");
    console.log("<tr><th colspan=\"3\">Blades</th></tr>");
    console.log("<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>");
    console.log("</thead>");
    console.log("<tbody>");
    
    for (var lineIndex in arr) {
        if (parseFloat(arr[lineIndex]) > 10) {
            
            var num = Math.floor(parseFloat(arr[lineIndex]));
            var sType;
            if (num <= 40) {
                sType = 'dagger';
            } else {
                sType = 'sword';
            }
            var typeBlade;
            var numFingers = num - Math.floor(num / 5) * 5;
            switch (numFingers) {
                case 1:
                    {
                        typeBlade = 'blade';
                    }
                    break;
                case 2:
                    {
                        typeBlade = 'quite a blade';
                    }
                    break;
                case 3:
                    {
                        typeBlade = 'pants-scraper';
                    }
                    break;
                case 4:
                    {
                        typeBlade = 'frog-butcher';
                    }
                    break;
                case 0:
                    {
                        typeBlade = '*rap-poker';
                    }
                    break;
                default:
            }
            console.log('<tr><td>' + num + '</td><td>' + sType + '</td><td>' + typeBlade + '</td></tr>');
        }
    }
    console.log('</tbody>');
    console.log('</table>');
};

var arr = ['17.8', '19.4', '13', '55.8', '126.96541651', '3'];

solve(arr);