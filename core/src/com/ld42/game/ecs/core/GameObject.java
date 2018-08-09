package com.ld42.game.ecs.core;

import java.util.Objects;

public class GameObject {

    private Engine engine;

    private String name;

    public Engine getEngine() {
        return engine;
    }

    public void setEngine(Engine engine) {
        this.engine = engine;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        GameObject that = (GameObject) o;
        return Objects.equals(engine, that.engine) &&
                Objects.equals(name, that.name);
    }

    @Override
    public int hashCode() {

        return Objects.hash(engine, name);
    }

    @Override
    public String toString() {
        return "GameObject{" +
                "engine=" + engine +
                ", name='" + name + '\'' +
                '}';
    }
}
