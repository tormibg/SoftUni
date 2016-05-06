if (!Object.create) {
    Object.create = function (proto) {
        function F() { };
        F.prototype = proto;
        return new F();
    };
};

if (!Object.extends) {
    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };
};

var Point = (function () {
    function Point(x, y) {
        this._x = x;
        this._y = y;
    };
    
    Point.prototype.toString = function () {
        return 'x: ' + this._x + ', y: ' + this._y;
    };
    return Point;
})();

var Shape = (function () {
    var Shape,
        Circle,
        Rectangle,
        Triangle,
        Line,
        Segment;

    Shape = (function () {
        function Shape(point, color) {
            this._point = point;
            this._color = color;
        }
        
        Shape.prototype.toString = function () {
            return this._point.toString() + ', color : ' + this._color;
        }
        return Shape;
    })();

    Circle = (function() {
        function Circle(point,color,r) {
            Shape.call(this, point, color);
            this._r = r;
        }

        Circle.extends(Shape);

        Circle.prototype.toString = function() {
            return 'Circle with radius ' + this._r + ' and ' + Shape.prototype.toString.call(this);
        }

        return Circle;
    })();

    Rectangle = (function() {
        function Rectangle(pointA,width,height,color) {
            Shape.call(this, pointA, color);
            this._width = width;
            this._height = height;
        }

        Rectangle.extends(Shape);

        Rectangle.prototype.toString = function() {
            return 'Rectangle with width: ' + this._width + ', height: ' + this._height + ', point top lef corner: ' + Shape.prototype.toString.call(this);
        }

        return Rectangle;
    })();

    Triangle = (function() {
        function Triangle(pointA, pointB, pointC, color) {
            Shape.call(this, pointA, color);
            this._pointB = pointB;
            this._pointC = pointC;
        }

        Triangle.extends(Shape);

        Triangle.prototype.toString = function() {
            return 'Triangle with pointC: ' + this._pointC + ', pointB: ' + this._pointB + ', pointA: ' + Shape.prototype.toString.call(this);
        };
        return Triangle;
    })();

    Line = (function() {
        function Line(pointA, pointB, color) {
            Shape.call(this, pointA, color);
            this._pointB = pointB;
        }

        Line.extends(Shape);

        Line.prototype.toString = function() {
            return 'Line with pointB: ' + this._pointB + ', pointA: ' + Shape.prototype.toString.call(this);
        }
        return Line;
    })();

    Segment = (function() {
        function Segment(pointA, pointB, color) {
            Shape.call(this, pointA, color);
            this._pointB = pointB;
        }

        Segment.extends(Shape);

        Segment.prototype.toString = function() {
            return 'Segment with pointB: ' + this._pointB + ', pointA: ' + Shape.prototype.toString.call(this);
        }
        return Segment;
    })();

    return {
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        Line: Line,
        Segment: Segment
    };
})();

var circle = new Shape.Circle(new Point(1, 1), '#FF0000', 10);
console.log(circle.toString());

var rectangle = new Shape.Rectangle(new Point(1, 1), 2,3,'#FF0000');
console.log(rectangle.toString());

var triangle = new Shape.Triangle(new Point(1, 1),new Point(2,2), new Point(3,3), '#FF0000');
console.log(triangle.toString());

var line = new Shape.Line(new Point(1, 1), new Point(2, 2),  '#FF0000');
console.log(line.toString());

var segment = new Shape.Segment(new Point(1, 1), new Point(2, 2), '#FF0000');
console.log(segment.toString());