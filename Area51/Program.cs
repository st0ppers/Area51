using Area51;

var conf = new Confidential();
var secret = new Secret();
var topSecret = new TopSecret();

var elevator = new Elevator();

elevator.GoToLevel(Floor.Ground, conf);
elevator.GoToLevel(Floor.Experimental, conf);
