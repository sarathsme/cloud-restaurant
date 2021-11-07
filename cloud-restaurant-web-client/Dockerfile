FROM node:14.18.1-alpine as build
WORKDIR /usr/local/app

COPY ./ /usr/local/app/
RUN npm install
RUN npm run build



FROM nginx:latest
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /usr/local/app/dist/cloud-restaurant-web-client /usr/share/nginx/html
