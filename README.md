# Newtonsoft Schema Enrichment

An experiment to prove that a minimalist JSON schema can be enriched upon deserialization to allow extending both a simple (string) value and a complex (object) value.

                                                                                                                                                                              
## Input

A JSON document which contains values of mixed type.

```
{                                                                                                                                                                              
    "Values": [                                                                                                                                                                
        "John",                                                                                                                                                                
        "Bobbie",                                                                                                                                                              
        { "name": "Johannes", "age": 32 }                                                                                                                                      
    ]                                                                                                                                                                          
}                                                   
```
## Output

The input document deserialises in to the enriched structure with no issues.
```
{
    "Values": [
        { "Name": "John", "Age": -1 },
        { "Name": "Bobbie", "Age": -1 },
        { "Name": "Johannes", "Age":32 }
    ]
}
```

## Implementation

The `Person` object is a simple POCO which has an implicit cast defined from `string`. 

When Newtonsoft encounters the string values it attempts to cast the `string` to a `Person` 
as defined in in the model, which activates this implicit cast.

This also gives us opportunities to define default values for deserialised objects in 
addition to the default values that might apply when instantiating the object in code with `new`;

```
public static implicit operator Person(string text)
{
    return new Person
    {
        Name = text,
        Age = -1
    };
}
```