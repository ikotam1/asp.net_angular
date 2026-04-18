# MyBlog Frontend

A modern Angular-based frontend for the MyBlog platform featuring a responsive start page with hero section, features showcase, and recent posts display.

## Features

- **Responsive Design**: Works seamlessly on desktop, tablet, and mobile devices
- **Modern UI**: Clean and professional interface with smooth animations
- **Angular 18**: Built with the latest Angular standalone components
- **Routing**: Pre-configured routing with lazy loading support
- **TypeScript**: Fully typed codebase for better development experience

## Project Structure

```
src/
├── app/
│   ├── pages/
│   │   └── start-page/          # Main landing page
│   │       ├── start-page.component.ts
│   │       ├── start-page.component.html
│   │       └── start-page.component.css
│   ├── app.component.ts         # Root component
│   ├── app.component.html
│   ├── app.component.css
│   ├── app.config.ts            # App configuration
│   └── app.routes.ts            # Routing configuration
├── main.ts                      # Application entry point
├── index.html                   # HTML template
└── styles.css                   # Global styles
```

## Prerequisites

- Node.js (v18 or higher)
- npm or yarn package manager

## Installation

1. Navigate to the frontend directory:
```bash
cd frontend
```

2. Install dependencies:
```bash
npm install
```

## Development

Start the development server:
```bash
npm start
```

The application will be available at `http://localhost:4200/`

### Development with file watching:
```bash
npm run dev
```

## Build

Create a production build:
```bash
npm run build
```

The compiled output will be in the `dist/` directory.

## Available Routes

- `/` - Start/Home page
- `/start` - Alternative route to start page
- `*` - Any unmatched route redirects to home

## Components

### StartPageComponent
The main landing page featuring:
- **Header/Navigation**: Logo and navigation links with authentication buttons
- **Hero Section**: Eye-catching banner with call-to-action buttons
- **Features Section**: Showcase of platform features with icons
- **Recent Posts**: Grid display of blog posts
- **Footer**: Site information and quick links

## Styling

The application uses CSS custom properties (CSS variables) for consistent theming:

- `--primary-color`: Main brand color (#2563eb)
- `--secondary-color`: Secondary background color (#f3f4f6)
- `--text-dark`: Primary text color (#1f2937)
- `--text-light`: Secondary text color (#6b7280)
- `--border-color`: Border color (#e5e7eb)
- `--shadow`: Standard box shadow
- `--shadow-lg`: Larger box shadow for emphasis

## Browser Support

- Chrome (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)

## Future Enhancements

- Authentication integration with backend API
- Blog post listing from API
- User profile pages
- Search functionality
- Category filtering
- Comments system

## Docker

A Dockerfile is included for containerized deployment.

Build the Docker image:
```bash
docker build -f Dockerfile -t myblog-frontend:latest .
```

Run the container:
```bash
docker run -p 80:80 myblog-frontend:latest
```

## License

Copyright © 2026 MyBlog. All rights reserved.
