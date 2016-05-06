'use strict';

Object.prototype.extend = function (properties) {
    function f() { };
    f.prototype = Object.create(this);
    for (var prop in properties) {
        f.prototype[prop] = properties[prop];
    }
    f.prototype._super = this;
    return new f();
}


var Point = {
    init: function (x, y) {
        this._x = x;
        this._y = y;
        return this;
    },
    
    toString: function () {
        return 'x: ' + this._x + ', y: ' + this._y;
    }
};

var Shape = (function () {
    var Shape,
        Circle,
        Rectangle,
        Triangle,
        Line,
        Segment;
    
    Shape = {
        init: function (point, color) {
            this._point = point;
            this._color = color;
            return this;
        },
        toString: function () {
            return this._point.toString() + ', color : ' + this._color;
        }
    };
    
    
    Circle = Object.create(Shape);
    Circle.init = function (point, r, color) {
        Shape.init.call(this, point, color);
        this._r = r;
        return this;
    };
    
    Circle.toString = function () {
        return 'Circle with radius ' + this._r + ' and ' + Shape.toString.call(this);
    };
    
    Rectangle = Shape.extend({
        init: function (pointA, width, height, color) {
            this._super.init.call(this, pointA, color);
            this._width = width;
            this._height = height;
            
            return this;
        },
        toString: function () {
            return 'Rectangle with width: ' + this._width + ', height: ' + this._height + ', point top lef corner: ' + this._super.toString.call(this);
        }
    });
    
    Triangle = Shape.extend({
        init: function (pointA, pointB, pointC, color) {
            this._super.init.call(this, pointA, color);
            this._pointB = pointB;
            this._pointC = pointC;
            
            return this;
        },
        toString: function () {
            return 'Triangle with pointC: ' + this._pointC + ', pointB: ' + this._pointB + ', pointA: ' + this._super.toString.call(this);
        }
    });
    
    Line = Shape.extend({
        init: function (pointA, pointB, color) {
            this._super.init.call(this, pointA, color);
            this._pointB = pointB;
            
            return this;
        },
        toString: function () {
            return 'Line with pointB: ' + this._pointB + ', pointA: ' + this._super.toString.call(this);
        }
    });
    
    Segment = Shape.extend({
        init: function (pointA, pointB, color) {
            this._super.init.call(this, pointA, color);
            this._pointB = pointB;
            
            return this;
        },
        toString: function () {
            return 'Segment with pointB: ' + this._pointB + ', pointA: ' + this._super.toString.call(this);
        }
    });
    
    return {
        //Shape: Shape
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        Line: Line,
        Segment: Segment
    };
})();

//var point = Object.create(Point).init(1, 2);
//console.log(point.toString());

//var shape = Object.create(Shape.Shape).init(Object.create(Point).init(1, 1), '#FF0000');
//console.log(shape.toString());

var circle = Object.create(Shape.Circle).init(Object.create(Point).init(1, 1), 10, '#FF0000');
console.log(circle.toString());

var rectangle = Object.create(Shape.Rectangle).init(Object.create(Point).init(1, 1), 2, 3, '#FF0000');
console.log(rectangle.toString());

var triangle = Object.create(Shape.Triangle).init(Object.create(Point).init(1, 1), Object.create(Point).init(2, 2), Object.create(Point).init(3, 3), '#FF0000');
console.log(triangle.toString());

var line = Object.create(Shape.Line).init(Object.create(Point).init(1, 1), Object.create(Point).init(2, 2), '#FF0000');
console.log(line.toString());

var segment = Object.create(Shape.Segment).init(Object.create(Point).init(1, 1), Object.create(Point).init(2, 2), '#FF0000');
console.log(segment.toString());