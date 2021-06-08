

const drawShape= {

    canvasElement: null,
    canvasContext: null,
    shapePath: null,
    size: null,
    firstCordinate: null,

    init(canvasId) {

        this.canvasElement = document.getElementById(canvasId);
        this.shapePath = JSON.parse(this.canvasElement.dataset.shape);
        this.size = this.shapePath.size;
        this.firstCoordinate = this.shapePath.coordinates[0];
        this.canvasContext = this.canvasElement.getContext('2d');

        this.draw();
    },

    draw() {
        switch (this.shapePath.shapePathType) {
            /*Arc*/
            case 1: this.drawShapeWithArc(); break;
            /*Line*/
            case 2: this.drawShapeWithLine(); break;
            /*Box*/
            case 3: this.drawShapeWithBox(); break;

            default:
        }
    },

    drawShapeWithArc() {
        this.canvasContext.beginPath();
        this.canvasContext.arc(this.firstCoordinate.xPoint, this.firstCoordinate.yPoint, this.size.radius, 0 * Math.PI, Math.PI * 2);
        this.canvasContext.closePath();
        this.canvasContext.stroke();
    },
    drawShapeWithLine() {
        this.canvasContext.beginPath();
        this.canvasContext.moveTo(this.firstCoordinate.xPoint, this.firstCoordinate.yPoint);

        for (var i = 1; i < this.shapePath.coordinates.length; i++) {
            var currentCoordinate = this.shapePath.coordinates[i];
            this.canvasContext.lineTo(currentCoordinate.xPoint, currentCoordinate.yPoint);
        }        
        
        this.canvasContext.closePath();
        this.canvasContext.stroke();
    },
    drawShapeWithBox() {
        
        this.canvasContext.beginPath();
        this.canvasContext.rect(this.firstCoordinate.xPoint, this.firstCoordinate.yPoint, this.size.width, this.size.width);
        this.canvasContext.stroke();
    },
}

