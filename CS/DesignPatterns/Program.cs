using DesignPatterns.Facade;
using DesignPatterns.Factory;
using DesignPatterns.Strategy;
// Strategy testing ----------------

var Bstrategy = new BikeStrategy();
var Cstrategy = new CarStrategy();

var Bmap = new Map(Bstrategy);
var Cmap = new Map(Cstrategy);

var start = new Coordinate();
var end = new Coordinate();

Bmap.CreateRoute(start, end);
Cmap.CreateRoute(start, end);

//  Factory testing  --------------

var shapeFactor = new ShapeFactory();

var circle = shapeFactor.CreateShape(ShapeType.Circle);
var rectangle = shapeFactor.CreateShape(ShapeType.Rectangle);

circle.Render();
rectangle.Render();

// Facade testing ------------------

var scanFacade = new ScanFacade();
scanFacade.Scan("https://github.com/Mateusz999/Embedded-System-Course/blob/main/src/oled.cpp");
