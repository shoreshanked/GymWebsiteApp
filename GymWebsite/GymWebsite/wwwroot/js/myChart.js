function myfunction(json) {

    //todo : make fabian read this. Help us
    var benchArray = [];
    var squatArray = [];
    var deadArray = [];

    if (json.hasOwnProperty("Bench Press")){
        var j = 0;
        do {
            benchArray.push(json["Bench Press"][j]["Item3"]);
            j = j + 1;
        } while (j < json["Bench Press"].length && json["Bench Press"].length);
    }
    else {
        console.log("bad");
    }

    if (json.hasOwnProperty("Squat")) {
        var x = 0;
        do {
            squatArray.push(json["Squat"][x]["Item3"]);
            x = x + 1;
        } while (x < json["Squat"].length && json["Squat"].length);
    }
    else {
        console.log("bad");
    }

    if (json.hasOwnProperty("Deadlift")) {
        var z = 0;
        do {
            deadArray.push(json["Deadlift"][z]["Item3"]);
            z = z + 1;
        } while (z < json["Deadlift"].length);
    }
    else {
        console.log("bad");
    }

    if (!json.hasOwnProperty("Deadlift") && !json.hasOwnProperty("Bench Press") && !json.hasOwnProperty("Squat")) {

    }
    else {
        buildChart(benchArray, squatArray, deadArray);
    }
    
}

function labelMaker(benchArray, squatArray, deadArray) {

    var b = benchArray.length;
    var s = squatArray.length;
    var d = deadArray.length;

    var max = Math.max(b, s, d);
    var labels = [];
    
    for (i = 1; i <= max; i++) {
        labels.push("Workout" + i)
    }

    return labels
}

function buildChart(benchArray, squatArray, deadArray) {
    var ctx = document.getElementById('myChart').getContext('2d');

    var labels = labelMaker(benchArray, squatArray, deadArray);

    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Bench',
                data: benchArray,
                backgroundColor: [
                    'rgba(0, 0, 0, 0.0)',
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                ],
                borderWidth: 3
            },
            {
                label: 'Squat',
                data: squatArray,
                backgroundColor: [
                    'rgba(0, 0, 0, 0.0)',
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)',
                ],
                borderWidth: 3
            },
            {
                label: 'Deadlift',
                data: deadArray,
                backgroundColor: [
                    'rgba(0, 0, 0, 0.0)',
                ],
                borderColor: [
                    'rgba(255, 206, 86, 1)',
                ],
                borderWidth: 3
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}
