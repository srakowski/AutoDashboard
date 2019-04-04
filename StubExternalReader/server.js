var net = require('net');

var server = net.createServer(function(socket) {
	socket.setEncoding('ASCII');
	socket.on('data', (data) => {
		console.log(data);
		if (data === "ping") {
			socket.write('pong');
		} else if (data === "sing") {
			socket.write('song');
		}
	});
});

server.listen(8088, '127.0.0.1');