FROM node:20 as build

WORKDIR /app

COPY package.json package.json
COPY package-lock.json package-lock.json

RUN npm i

COPY . .

RUN npm run build:prod

FROM nginx:alpine

COPY --from=build /app/nginx.default.conf /etc/nginx/templates/nginx.default.conf
COPY --from=build /app/dist /usr/share/nginx/html

# Expose the default nginx port
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]