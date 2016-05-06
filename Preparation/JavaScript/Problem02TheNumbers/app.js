function solve(arr) {
    var str = arr[0];
    str = (str.replace(/\D+/g, ' ').trim().split(/\s/));
    //console.log(str);
    var nArray = [];
    for (var string in str) {
        var num = Number(str[string]);
        var hexStr = num.toString(16).toUpperCase();
        var tmpStr = "" + hexStr;
        var pad = '0000';
        var ans = '0x' + pad.substring(0, pad.length - tmpStr.length) + tmpStr;
        nArray.push(ans);
    };
    console.log(nArray.join('-'));
};

//var arr = ['5tffwj(//*7837xzc2---34rlxXP%$”.'];
//var arr = ['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312'];
var arr = ['20'];

solve(arr);