$(document).ready(function () {})
function CreateGauge1(val,maxVal){
    var opts1 = {
        lines: 12, // The number of lines to draw
        angle: 0.35, // The length of each line
        lineWidth: 0.1, // The line thickness
        pointer: {
            length: 0.9, // The radius of the inner circle
            strokeWidth: 0.035, // The rotation offset
            color: '#000000' // Fill color
        },
        limitMax: 'false',   // If true, the pointer will not go past the end of the gauge
        colorStart: '#0066A1',   // Colors
        colorStop: '#008FFF',    // just experiment with them
        strokeColor: '#EEEEEE',   // to see which ones work best for you
        generateGradient: true,

    };
    
    var target1 = document.getElementById('Apps'); // your canvas element var gauge = new Donut(target).setOptions(opts); // create sexy gauge!
    var gauge1 = new Donut(target1).setOptions(opts1);
    if (val > 500) {
        gauge1.maxValue = Math.ceil(val / 1000) * 1000;
    } else {
        gauge1.maxValue = Math.ceil(val / 100) * 100;
    }
    gauge1.maxValue = Math.ceil(val / 100) * 100; // set max gauge value gauge.animationSpeed = 100; // set animation speed (32 is default value) gauge.set(67); // set actual value
    gauge1.animationSpeed = 150;
    gauge1.set(val);

}
function CreateGauge2(val){
    var opts = {
        lines: 12, // The number of lines to draw
        angle: 0.35, // The length of each line
        lineWidth: 0.1, // The line thickness
        pointer: {
            length: 0.9, // The radius of the inner circle
            strokeWidth: 0.035, // The rotation offset
            color: '#000000' // Fill color
        },
        limitMax: 'false',   // If true, the pointer will not go past the end of the gauge
        colorStart: '#0066A1',   // Colors
        colorStop: '#008FFF',    // just experiment with them
        strokeColor: '#EEEEEE',   // to see which ones work best for you
        generateGradient: true
    };
    var target = document.getElementById('Pages'); // your canvas element var gauge = new Donut(target).setOptions(opts); // create sexy gauge!
    var gauge = new Donut(target).setOptions(opts);
    if (val > 500) {
        gauge.maxValue = Math.ceil(val / 1000) * 1000;
    } else {
        gauge.maxValue = Math.ceil(val / 100) * 100;
    }
   
    gauge.animationSpeed = 150;
    gauge.set(val);
}

function CreateGauge3(val){
    var opts = {
        lines: 12, // The number of lines to draw
        angle: 0.35, // The length of each line
        lineWidth: 0.1, // The line thickness
        pointer: {
            length: 0.9, // The radius of the inner circle
            strokeWidth: 0.035, // The rotation offset
            color: '#000000' // Fill color
        },
        limitMax: 'false',   // If true, the pointer will not go past the end of the gauge
        colorStart: '#0066A1',   // Colors
        colorStop: '#008FFF',    // just experiment with them
        strokeColor: '#EEEEEE',   // to see which ones work best for you
        generateGradient: true
    };
    var target = document.getElementById('Users'); // your canvas element var gauge = new Donut(target).setOptions(opts); // create sexy gauge!
    var gauge = new Donut(target).setOptions(opts);
    if (val > 500) {
        gauge.maxValue = Math.ceil(val / 1000) * 1000;
    } else {
        gauge.maxValue = Math.ceil(val / 100) * 100;
    }
    gauge.animationSpeed = 150;
    gauge.set(val);
}

function CreateGauge4(val){
    var opts = {
        lines: 12, // The number of lines to draw
        angle: 0.35, // The length of each line
        lineWidth: 0.1, // The line thickness
        pointer: {
            length: 0.9, // The radius of the inner circle
            strokeWidth: 0.035, // The rotation offset
            color: '#000000' // Fill color
        },
        limitMax: 'false',   // If true, the pointer will not go past the end of the gauge
        colorStart: '#0066A1',   // Colors
        colorStop: '#008FFF',    // just experiment with them
        strokeColor: '#EEEEEE',   // to see which ones work best for you
        generateGradient: true
    };
    var target = document.getElementById('ActiveUsers'); // your canvas element var gauge = new Donut(target).setOptions(opts); // create sexy gauge!
    var gauge = new Donut(target).setOptions(opts);
    if (val > 500) {
        gauge.maxValue = Math.ceil(val / 1000) * 1000;
    } else {
        gauge.maxValue = Math.ceil(val / 100) * 100;
    }
    gauge.animationSpeed = 150;
    gauge.set(val);
}
