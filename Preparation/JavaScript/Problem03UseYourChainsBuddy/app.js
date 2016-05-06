function solve(arr) {
    var pattern = new RegExp(/<p>(.+?)<\/p>/g);
    var html = arr[0];
    var matchArray;
    result = "";
    while ((matchArray = pattern.exec(html))) {
        var match = matchArray[1];
        match = match.replace(/[^a-z0-9]+/g, " ");
        for (var ch in match) {
            var newCharCode;
            if (match[ch] >= 'a' && match[ch] <= 'm') {
                newCharCode = match.charCodeAt(ch) + 13;
            } else if (match[ch] >= 'n' && match[ch] <= 'z') {
                newCharCode = match.charCodeAt(ch) - 13;
            } else {
                newCharCode = match.charCodeAt(ch);
            }
            result += String.fromCharCode(newCharCode);
        }
    }
    console.log(result);   
};

//var arr = ['<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>'];

var arr = ['<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj punvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf </p><div>It is frustrating that you have not put car chains yet... Embarrassing...</div><p>orsber lbh ernpu fabjl ebnqf lbh jvyy znxr lbhe yvsr jnl rnfvre</p></body>'];

solve(arr);