function buildExerciseArrays(exercises) {

    console.log(exercises);
    //todo : make fabian read this. Help us
    var benchArray = [];
    var squatArray = [];
    var deadArray = [];

    if (exercises.hasOwnProperty("Bench Press")){
        var j = 0;
        do {
            benchArray.push(exercises["Bench Press"][j]["Item3"]);
            j = j + 1;
        } while (j < exercises["Bench Press"].length && exercises["Bench Press"].length);
    }
    else {
        console.log("bad");
    }

    if (exercises.hasOwnProperty("Squat")) {
        var x = 0;
        do {
            squatArray.push(exercises["Squat"][x]["Item3"]);
            x = x + 1;
        } while (x < exercises["Squat"].length && exercises["Squat"].length);
    }
    else {
        console.log("bad");
    }

    if (exercises.hasOwnProperty("Deadlift")) {
        var z = 0;
        do {
            deadArray.push(exercises["Deadlift"][z]["Item3"]);
            z = z + 1;
        } while (z < exercises["Deadlift"].length);
    }
    else {
        console.log("bad");
    }

    if (!exercises.hasOwnProperty("Deadlift") && !exercises.hasOwnProperty("Bench Press") && !exercises.hasOwnProperty("Squat")) {

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
        labels.push("Workout " + i)
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
