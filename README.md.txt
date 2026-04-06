Security Implementation: JWT & Cookies

This project uses HTTP-only cookies to store JWT tokens. This is a critical security measure because HTTP-only cookies cannot be accessed by client-side JavaScript. This design choice effectively mitigates Cross-Site Scripting (XSS) attacks, ensuring that malicious scripts cannot steal user authentication tokens.