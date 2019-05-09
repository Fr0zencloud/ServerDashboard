build:
	docker build -t dashboardhelper .

startup:
	docker run -d -p 3000:3000 --hostname Macbook --name dashboard_helper dashboardhelper

stop:
	docker stop dashboard_helper
	docker rm dashboard_helper