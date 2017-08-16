var assessmentAvg = [];
function graphKPI() {
    var myCanvas = document.getElementById('canvasKPI');
    var ctx = myCanvas.getContext('2d');
    myCanvas.width = 740;
    myCanvas.height = 500;
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, 700, 400);
    drawGrid(ctx);
    labelGridNumbers(ctx);
}
function graphAssessment() {
    var myCanvas = document.getElementById('canvasAssessment');
    var ctx = myCanvas.getContext('2d');
    myCanvas.width = 740;
    myCanvas.height = 425;
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, 700, 400);
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
    drawLine(ctx, 20, 88, 700, 88, "gray");
    drawLine(ctx, 20, 166, 700, 166, "gray");
    drawLine(ctx, 20, 244, 700, 244, "gray");
    drawLine(ctx, 20, 322, 700, 322, "gray");
    drawLine(ctx, 20, 400, 700, 400, "gray");
    drawLine(ctx, 20, 10, 20, 400, "grey");
    drawLine(ctx, 700, 10, 700, 400, "grey");
}
function drawABar(ctx, upperLeftX, upperLeftY, width, height, color) {
    ctx.save();
    ctx.fillStyle = color;
    ctx.fillRect(upperLeftX, upperLeftY, width, height);
    ctx.restore();
}
function drawBarsAssessment(ctx) {
    drawABar(ctx, 25, (400 - ((parseFloat(assessmentAvg[0])) * 78)), 110, 400, "blue");
    drawABar(ctx, 165, (400 - ((parseFloat(assessmentAvg[1])) * 78)), 110, 400, "blue");
    drawABar(ctx, 305, (400 - ((parseFloat(assessmentAvg[2])) * 78)), 110, 400, "blue");
    drawABar(ctx, 445, (400 - ((parseFloat(assessmentAvg[3])) * 78)), 110, 400, "blue");
    drawABar(ctx, 585, (400 - ((parseFloat(assessmentAvg[4])) * 78)), 110, 400, "blue");
    drawABar(ctx, 20, 400, 700, 400, "white")
}
function label(ctx, text, bottomLeftX, bottomLeftY) {
    ctx.save();
    ctx.fillStyle = "#435a6b";
    ctx.font = 'italic 10pt Raleway';
    ctx.fillText(text, bottomLeftX, bottomLeftY, 110);
    ctx.restore();
}
function labelGridNumbers(ctx) {
    label(ctx, "0", 0, 405);
    label(ctx, "1", 0, 327);
    label(ctx, "2", 0, 249);
    label(ctx, "3", 0, 171);
    label(ctx, "4", 0, 93);
    label(ctx, "5", 0, 15);
}
function labelGridAssessment(ctx) {
    label(ctx, "Accountiability & Dependability", 25, 415);
    label(ctx, "Customer Service & Relationships", 165, 415);
    label(ctx, "Technical Delivery", 305, 415);
    label(ctx, "Motivation & Initiative", 445, 415);
    label(ctx, "Training & Mentoring", 585, 415);
}