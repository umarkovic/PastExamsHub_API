https://slproweb.com/products/Win32OpenSSL.html
https://stackoverflow.com/questions/10175812/how-to-create-a-self-signed-certificate-with-openssl

openssl req -x509 -newkey rsa:4096 -keyout key.pem -out cert.pem -days 365
openssl pkcs12 -export -out cert.pfx -inkey key.pem -in cert.pem

Country Name (2 letter code) [AU]:AU
State or Province Name (full name) [Some-State]:Victoria
Locality Name (eg, city) []:Melbourne
Organization Name (eg, company) [Internet Widgits Pty Ltd]:TEMPLATE CO
Organizational Unit Name (eg, section) []:
Common Name (e.g. server FQDN or YOUR name) []:*.template.com
Email Address []:ssl@template.com