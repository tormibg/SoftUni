(function () {
    'use strict';
    
    function traverse(selector) {
        var el = document.querySelector(selector);
        //console.log(el);
        
        function traversNode(node, spacing) {
            spacing = spacing || '';
            var nodeId = node.getAttribute('id'),
                nodeClass = node.getAttribute('class'),
                nodeName = node.nodeName.toLowerCase(),
                strToPrint = spacing + nodeName + ':' + (nodeId ? ' id="' + nodeId + '"' : '') + 
                (nodeClass ? ' class="' + nodeClass + '"' : ''),
                i,
                child,
                nodeChildNodesLength = node.childNodes.length;
            
            console.log(strToPrint);
            
            for (i = 0; i < nodeChildNodesLength; i++) {
                child = node.childNodes[i];
                if (child.nodeType === document.ELEMENT_NODE) {
                    traversNode(child, spacing + '    ');
                }
            }
        };
        
        traversNode(el, "");
    };
    
    var selector = ".birds";
    traverse(selector);

})();