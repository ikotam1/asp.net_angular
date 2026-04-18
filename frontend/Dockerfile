# Use Node.js to build the Angular app
FROM node:18 AS build
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code
COPY . .

# Build the app
RUN npm run build --prod

# Use nginx to serve the app
FROM nginx:alpine
COPY --from=build /app/dist/my-blog /usr/share/nginx/html

# Expose port 80
EXPOSE 80