# Author: Ahmed Elgebaly

# Proxy Generation :
- Proxy takes apis, look at inputs, outputs and start generating [backend must be up first].
- the angular app knows the backend from environment.ts file from apis field.

## to generate proxy:
- abp generate-proxy -t ng

* After generating proxy, you can now use it inside your angular components

- to create module for category in angular:
ng g m modules/categories --routing --dry-run

explain '--routing' : make seperate routing for this module to control it seperately

NOTE: The "--dry-run" option means no changes were made. [Just try the command to see its response], and after see remove --dry-run from the command.

- you can now generate components inside each module like:
ng g c modules/products/listProducts -m Products --skip-tests --dry-run

NOTE: '-m' flag means that the component belongs to this module.
and '--skip-tests' don't make .spec.ts files

---------

-> route.provider.ts : this file responsable for sideMenu, put items in side menu with its route

NOTE: "::Menu:Home" this is related to localization

- you must define path for each route [to module] inside app.routes.ts

- And you must define routes for components inside module routing file,
if he not put anything after /products [this is path for module], redirect it to list-products component and render it inside module..

* inside each ts for the component, inject the service from proxy and use it to communicate with backend apis

---

>> لو جينا نتكلم عن البروكسي فأي تعديل انا بعمله في الباك اند بيسمع في الفرونت تلقائي لما اعمل generate-proxy تاني

---


