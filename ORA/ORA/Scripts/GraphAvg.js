var assessmentAvg = [];
function graphKPI() {
    var myCanvas = document.getElementById('canvasKPI');
    var ctx = myCanvas.getContext('2d');
    myCanvas.width = 740;
    myCanvas.height = 600;
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, 700, 560);
    drawGrid(ctx);
    labelGridNumbers(ctx);
}
function graphAssessment() {
    var myCanvas = document.getElementById('canvasAssessment');
    var ctx = myCanvas.getContext('2d');
    myCanvas.width = 740;
    myCanvas.height = 600;
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, 700, 560);
    drawGrid(ctx);
    drawBarsAssessment(ctx);
    labelGridNumbers(ctx);
    labelGridAssessment(ctx);
}
function drawLine(ctx, startX, startY, endX, endY, color) {
    ctx.save();
    ctx.strokeStyle = color;
    ctx.beginPath();
    ctx.moveTo(startX, startY);
    ctx.lineTo(endX, endY);
    ctx.stroke();
    ctx.restore();
}
function drawGrid(ctx) {
    drawLine(ctx, 20, 10, 700, 10, "gray");
    drawLine(ctx, 20, 120, 700, 120, "gray");
    drawLine(ctx, 20, 230, 700, 230, "gray");
    drawLine(ctx, 20, 340, 700, 340, "gray");
    drawLine(ctx, 20, 450, 700, 450, "gray");
    drawLine(ctx, 20, 560, 700, 560, "gray");
    drawLine(ctx, 20, 10, 20, 560, "grey");
    drawLine(ctx, 700, 10, 700, 560, "grey");
}
function drawABar(ctx, upperLeftX, upperLeftY, width, height, color) {
    ctx.save();
    ctx.fillStyle = color;
    ctx.fillRect(upperLeftX, upperLeftY, width, height);
    ctx.restore();
}
function drawBarsAssessment(ctx) {
    drawABar(ctx, 25, (560 - ((parseFloat(assessmentAvg[0])) * 110)), 110, 560, "blue");
    drawABar(ctx, 165, (560 - ((parseFloat(assessmentAvg[1])) * 110)), 110, 560, "blue");
    drawABar(ctx, 305, (560 - ((parseFloat(assessmentAvg[2])) * 110)), 110, 560, "blue");
    drawABar(ctx, 445, (560 - ((parseFloat(assessmentAvg[3])) * 110)), 110, 560, "blue");
    drawABar(ctx, 585, (560 - ((parseFloat(assessmentAvg[4])) * 110)), 110, 560, "blue");
    drawABar(ctx, 20, 560, 700, 560, "white")
}
function label(ctx, text, bottomLeftX, bottomLeftY) {
    ctx.save();
    ctx.fillStyle = "#435a6b";
    ctx.font = 'italic 10pt Raleway';
    ctx.fillText(text, bottomLeftX, bottomLeftY, 110);
    ctx.restore();
}
function labelGridNumbers(ctx) {
    label(ctx, "0", 0, 565);
    label(ctx, "1", 0, 455);
    label(ctx, "2", 0, 345);
    label(ctx, "3", 0, 235);
    label(ctx, "4", 0, 125);
    label(ctx, "5", 0, 15);
}
function labelGridAssessment(ctx) {
    label(ctx, "Accountiability & Dependability", 25, 580)
    label(ctx, "Customer Service & Relationships", 165, 580)
    label(ctx, "Technical Delivery", 305, 580)
    label(ctx, "Motivation & Initiative", 445, 580)
    label(ctx, "Training & Mentoring", 585, 580)
}