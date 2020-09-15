const crypto = require('crypto');
 
function createHmac (authObject, secretKey) {
   try {
     let dvhString =  Buffer.from(JSON.stringify(authObject)).toString('base64');
     return crypto.createHmac(`SHA512`, secretKey).update(dvhString).digest('hex');
   } catch (error) {
     throw error;
   }
 };

let request = {
 "amount": 100.5,
 "apiKey": "3568f8c7-3f33-49dc-bbc9-9362c130f7c8",
 "bankCode": "GIBL",
 "currency": "NPR",
 "dateOfRequest": "2020-09-10",
 "dvh": "01f0bb5021822af7dc911e2d2a1684930fd5887f38da909d33b37641d14baa842c1c103e30b31a135e4615bcbe0d1a7b26c2abf5dda8c4c3680104a0e88006bf",
 "referenceId": "Drz9699731138518"
}

 let { dvh, metaData, context, ...validationObject } = request;   
 let secretKey ='3568f8c73f3349dcbbc99362c130f7c8'   

request.dvh = createHmac(validationObject,secretKey )

 console.log(JSON.stringify(request))


 