# Fskab Web Map

## About
### Backend
- ASP.NET Core

### Frontend 
- React
- Leaflet

## Prerequisites
- [Node](https://nodejs.org/en/download/)
- [Yarn](https://yarnpkg.com/lang/en/docs/install/#windows-stable) or [Npm](https://www.npmjs.com/get-npm)
- .Net
- (Optional) Visual Studio 2019

## How to
- Run `yarn install` or `npm install` in `/ClientApp`
- Start project from visual studio.

### Functionality
Basic functionality for returning a path and for returning a group of coordinates exists. The frontend can draw the groups and paths on a map.
Currently the grouping algorithm and the path algorithm only returns dummy results.

# Todo
- [ ] Create an algorithm that returns a grouping of coordinates using the zoom input. 
- All coordinates need to be grouped (but can be alone in a group). 
- The zoom variable should change the distance with which coordinates can be grouped so that higher values gives larger groups.
- A zoom value of 0 gives each coordinate it's own group.

- [ ] Create an algorithm that calculates the shortest path between all of the coorinates inputted. 
- The first coordinate in the input will be the start of the path and the last one will be the end. 

- [ ] Write appropriate tests for both algorithms.

- [ ] Add a form and an endpoint to create a new coordinate.

- [ ] Make it possible to add a coordinate by interacting with the map.
